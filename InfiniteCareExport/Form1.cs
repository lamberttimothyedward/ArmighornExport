using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateSubAccount;
using FileHelpers;
using NLog;
using System.Text.RegularExpressions;
using ProgramExpiryWizard;
using FileExportHarness;
using GetUserInfo;
using MimeKit;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Threading;
using Dropbox.Api;
using Dropbox.Api.Files;
using Rebex.Net;
using OfficeOpenXml;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using FluentFTP;
using System.Net;
using System.Globalization;
using InfiniteCareExport;

namespace CreateBridgeCourses
{
    public partial class Form1 : Form
    {
        public string DeliveryMethod = "";
        private static Logger logger;
        public int domainId = 0;
        public int bridgeId = 0;
        public string courseType = "";
        CourseRootObject cro = new CourseRootObject();
        InfiniteCareExport2.CourseRootobject2 cro2 = new InfiniteCareExport2.CourseRootobject2();
        CourseTitlesRootObject ct = new CourseTitlesRootObject();


        public Form1()
        {
            InitializeComponent();
        }

        private async Task getDomainID(string subdomain = "")
        {
            Sub_Accounts sa = new Sub_Accounts();
            ApiHelper.IninitializeClient();


            sa = await Processor.connectToDomain(subdomain);
            if (sa != null && sa.id != "1")
            {
                
            }
            else
            {

                //Now connect
                sa = await Processor.connectToDomain(subdomain);
                
                txtSubID.Text = sa.id.ToString();
            }
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            if (logger == null) logger = LogManager.GetCurrentClassLogger();
            DateTime dt = DateTime.Now;
            DateTime lastdt = DateTime.Now;
            //var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var culture = new CultureInfo("en-US", false);
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            dt = dt.AddDays(-diff).Date;
            dt = dt.AddDays(-7).Date;
            var dateString2 = dt.ToString("yyyy-MM-dd");
            lastdt = dt.AddDays(6);

            var dateString3 = lastdt.ToString("yyyy-MM-dd");
            txtStart.Text = dateString2;
            txtEnd.Text = dateString3;
            this.txtSubURL.Text = "https://";
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string defaultDomain = System.Configuration.ConfigurationManager.AppSettings["defaultDomain"];
            if (!string.IsNullOrEmpty(defaultDomain))
            {
                ApiHelper.IninitializeClient();
                this.txtDomain.Text = defaultDomain;
                string domain = txtDomain.Text.Replace(" ", "");
                if (txtSubURL.Text == "https://")
                {
                    this.txtSubURL.Text = txtSubURL.Text + defaultDomain + "-acc.bridgeapp.com";
                }

                Sub_Accounts sa = new Sub_Accounts();
                ApiHelper.IninitializeClient();


                sa = await Processor.connectToDomain(this.txtSubURL.Text);
                if (sa != null && sa.id != "1")
                {
                    txtSubID.Text = sa.id.ToString();
                    txtAccountName.Text = sa.name.ToString();
                    logger.Info("Retrieved Domain. Press Export to download records.");
                    this.btnExport.Enabled = true;
                    this.txtDomain.ReadOnly = true;
                    this.txtSubID.ReadOnly = true;
                    this.txtDomain.ReadOnly = true;
                    this.txtSubURL.ReadOnly = true;
                    this.txtAccountName.ReadOnly = true;
                    this.btnExport.Focus();
                }
                else
                {
                    MessageBox.Show("This Subaccount does not exist. ");
                }
            }
            

          }

 

 
        private async void txtDomain_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtDomain.Text))
            {
                string domain = txtDomain.Text.Replace(" ", "");
                if (txtSubURL.Text == "https://")
                {
                       this.txtSubURL.Text = txtSubURL.Text + domain + "-acc.bridgeapp.com";
                 }
            }
            Sub_Accounts sa = new Sub_Accounts();
            ApiHelper.IninitializeClient();


            sa = await Processor.connectToDomain(this.txtSubURL.Text);
            if (sa != null && sa.id != "1")
            {
                txtSubID.Text = sa.id.ToString();
                txtAccountName.Text = sa.name.ToString();
                
            }
            else
            {
                MessageBox.Show("This Subaccount does not exist. ");
            }

        }


        private void txtSubURL_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtAccountName.Text))
            {
                txtAccountName.Text = txtDomain.Text;
            }
        }

  
        private async void btnExport_Click(object sender, EventArgs e)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("starting...");
            ApiHelper.IninitializeClient();
            this.txtStart.ReadOnly = true;
            this.txtEnd.ReadOnly = true;

            var list = new List<FileOutput>();

            logger.Info("Retrieving Completed learning for: " + txtStart.Text + " to " + txtEnd.Text);
            CLDatum[] dt = await Processor.getCompletedLearning(txtSubURL.Text, txtEnd.Text, txtStart.Text, "COMPLETEDLEARNERS");

                if (dt.Length > 0)
                {
                     foreach (CLDatum d in dt)
                    {
                    User usr = new User();
                    usr = await Processor.getUser(txtSubURL.Text, d.user_id.ToString());
                    string firstname = usr.first_name?.ToString();
                    string lastname = usr.last_name?.ToString();
                    string fullname = firstname + " " + lastname;
                    string course_id = "";
                    course_id = d.course_id;

                    if(string.IsNullOrEmpty(course_id))
                    {
                        course_id = d.course.ToString();
                    }
                    string createdat = "";
                    if (!string.IsNullOrEmpty(d.created_at))
                    {
                        createdat = d.created_at.Substring(0,10);
                        string reformattedyear = createdat.Substring(0, 4);
                        string reformattedmonth = createdat.Substring(5, 2);
                        string reformattedday = createdat.Substring(8, 2);
                        createdat = reformattedday + "/" + reformattedmonth + "/" + reformattedyear;
                    }
                    string completedat =  "";
                    if (!string.IsNullOrEmpty(d.completed_at))
                    {
                        completedat = d.completed_at.Substring(0, 10);
                        string reformattedyear = completedat.Substring(0, 4);
                        string reformattedmonth = completedat.Substring(5, 2);
                        string reformattedday = completedat.Substring(8, 2);
                        completedat = reformattedday + "/" + reformattedmonth + "/" + reformattedyear;
                    }

                    string duedate = "";
                    if (!string.IsNullOrEmpty(d.due_date))
                    {
                        duedate = d.due_date.Substring(0, 10);
                        string reformattedyear = duedate.Substring(0, 4);
                        string reformattedmonth = duedate.Substring(5, 2);
                        string reformattedday = duedate.Substring(8, 2);
                        duedate = reformattedday + "/" + reformattedmonth + "/" + reformattedyear;
                    }

                        list.Add(new FileOutput
                        {
                            status = d.state,
                            Location = d.custom_field_location,
                            Position = d.custom_field_position
                        });


                    }
                }
                else
                {
                    logger.Info("There were no completed learning records for today");
                }

            logger.Info("Retrieving Overdue learning for: " + txtStart.Text + " to " + txtEnd.Text);
            OLDatum[] ol = await Processor.getOverdueLearning(txtSubURL.Text, txtEnd.Text, txtStart.Text);
            if (ol.Length > 0)
            {
                foreach (OLDatum d in ol)
                {
                    User usr = new User();
                    usr = await Processor.getUser(txtSubURL.Text, d.user_id.ToString());
                    string firstname = usr.first_name?.ToString();
                    string lastname = usr.last_name?.ToString();
                    string fullname = firstname + " " + lastname;
                    string course_id = "";
                    course_id = d.course_id;

                    if (string.IsNullOrEmpty(course_id))
                    {
                        course_id = d.course.ToString();
                    }
                    string createdat = "";
                    string hrsid = usr.hris_id?.ToString();
                    if (!string.IsNullOrEmpty(d.created_at))
                    {
                        createdat = d.created_at.Substring(0, 10);
                        string reformattedyear = createdat.Substring(0, 4);
                        string reformattedmonth = createdat.Substring(5, 2);
                        string reformattedday = createdat.Substring(8, 2);
                        createdat = reformattedday + "/" + reformattedmonth + "/" + reformattedyear;
                    }

                    string duedate = "";
                    if (!string.IsNullOrEmpty(d.due_date))
                    {
                        duedate = d.due_date.Substring(0, 10);
                        string reformattedyear = duedate.Substring(0, 4);
                        string reformattedmonth = duedate.Substring(5, 2);
                        string reformattedday = duedate.Substring(8, 2);
                        duedate = reformattedday + "/" + reformattedmonth + "/" + reformattedyear;
                    }
                    list.Add(new FileOutput
                    {

                        status = d.state,
                        Location = d.custom_field_location,
                        Position = d.custom_field_position
                    });

                }
            }
            else
            {
                logger.Info("There were no overdue learning records");
            }


            logger.Info("Retrieving Incomplete learning for: " + txtStart.Text + " to " + txtEnd.Text);
            ILDatum[] il = await Processor.getInCompleLearning(txtSubURL.Text, txtEnd.Text, txtStart.Text);

            if (il.Length > 0)
            {
                foreach (ILDatum d in il)
                {
                    User usr = new User();
                    usr = await Processor.getUser(txtSubURL.Text, d.user_id.ToString());
                    string firstname = usr.first_name?.ToString();
                    string lastname = usr.last_name?.ToString();
                    string fullname = firstname + " " + lastname;
                    string course_id = "";
                    course_id = d.course_id;

                    if (string.IsNullOrEmpty(course_id))
                    {
                        course_id = d.course.ToString();
                    }
                    string createdat = "";
                    string hrsid = usr.hris_id?.ToString();
                    if (!string.IsNullOrEmpty(d.created_at))
                    {
                        createdat = d.created_at.Substring(0, 10);
                        string reformattedyear = createdat.Substring(0, 4);
                        string reformattedmonth = createdat.Substring(5, 2);
                        string reformattedday = createdat.Substring(8, 2);
                        createdat = reformattedday + "/" + reformattedmonth + "/" + reformattedyear;
                    }
                    string completedat = "";
                    if (!string.IsNullOrEmpty(d.completed_at))
                    {
                        completedat = d.completed_at.Substring(0, 10);
                        string reformattedyear = completedat.Substring(0, 4);
                        string reformattedmonth = completedat.Substring(5, 2);
                        string reformattedday = completedat.Substring(8, 2);
                        completedat = reformattedday + "/" + reformattedmonth + "/" + reformattedyear;
                    }
                    string duedate = "";
                    if (!string.IsNullOrEmpty(d.due_date))
                    {
                        duedate = d.due_date.Substring(0, 10);
                        string reformattedyear = duedate.Substring(0, 4);
                        string reformattedmonth = duedate.Substring(5, 2);
                        string reformattedday = duedate.Substring(8, 2);
                        duedate = reformattedday + "/" + reformattedmonth + "/" + reformattedyear;
                    }
                    list.Add(new FileOutput
                    {
                        //employee_name = fullname,
                        //title = d.course_template_title?.ToString(),
                        //duedate = duedate,
                        //completed_at = completedat,
                        status = d.state,
                        Location = d.custom_field_location,
                        Position = d.custom_field_position
                    });

                }
            }
            else
            {
                logger.Info("There were no incomplete learning records");
            }

            if (list.Count > 0)
                {
                logger.Info("Retrieved " + list.Count.ToString() + " records.");

                string fileName = "Learning_Records-" + DateTime.Now.ToString("yyyyMMddHHmmss").Replace(" / ", "-") + ".xlsx";
                    string StagingPath = @ConfigurationManager.AppSettings["StagingFolder"] ;
                    string ProcessedPath = @ConfigurationManager.AppSettings["ProcessedFolder"];


                using (ExcelPackage excelpackage = new ExcelPackage())
                {
                    //Create an Excel worksheet
                    ExcelWorksheet worksheet = excelpackage.Workbook.Worksheets.Add("Export");

                    worksheet.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Medium16);

                    FileInfo fi = new FileInfo(StagingPath + fileName);
                    excelpackage.SaveAs(fi);
                    logger.Info("Saved file to: " + StagingPath + fileName);
                }

                //logger.Info("retrieving FTP credentials...");
                //    string host = @ConfigurationManager.AppSettings["SFTPHostName"];
                //    string username = @ConfigurationManager.AppSettings["SFTPUsername"];
                //    string password = @ConfigurationManager.AppSettings["SFTPPassword"];



                //using (SftpClient sftp = new SftpClient(host, username, password))
                //    {
                //    logger.Info("Attempting to FTP file...");
                //        try
                //        {
                //        //Regular FTP
                //        FtpClient client = new FtpClient(host);
                //        client.Credentials = new NetworkCredential(username, password);
                //        logger.Info("Connecting to FTP Server...");
                //        client.Connect();
                //        logger.Info("Successfuly connected to FTP Server.");
                //        client.UploadFile(StagingPath + fileName, "");
                //        logger.Info("File upload successfully to FTP Server.");
                //        client.Disconnect();
                //        logger.Info("Disconnecting from FTP Server.");
                //        //Secure FTP AKA SFTP
                //        //sftp.Connect();
                //        //using (var fileStream = new FileStream(StagingPath + fileName, FileMode.Open))
                //        //{
                //        //    sftp.UploadFile(fileStream, fileName);
                //        //}
                //        //sftp.Disconnect();
                //        logger.Info("moving file to processed folder");
                //        try
                //            {
                //                if (File.Exists(ProcessedPath + fileName))
                //                {
                //                    File.Delete(ProcessedPath + fileName);
                //                }
                                    

                //                // Move the file.
                //                File.Move(StagingPath + fileName, ProcessedPath + fileName);
                //            logger.Info("File Moved to processed folder.");
                //            }
                //            catch
                //            {

                //            }
                //            MessageBox.Show("File Sent: " + fileName);

                //        }
                //        catch (Exception ex)
                //        {
                //        logger.Error("Exception:" + ex.Message.ToString());
                //            Console.WriteLine("An exception has been caught " + ex.ToString());
                //        }
                //    }
                }
        }

        private async void btnExportEnrollments_Click(object sender, EventArgs e)
        {
            //get a list of courses which have more than one enrollment

            //get a list of users & custom fields


            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("starting...");
            ApiHelper.IninitializeClient();
            this.txtStart.ReadOnly = true;
            this.txtEnd.ReadOnly = true;

            var list = new List<FileOutput>();
            cro2.course_templates = await Processor.getCourses(txtSubURL.Text);
            logger.Info("Retrieving Completed learning for: " + txtStart.Text + " to " + txtEnd.Text);
            foreach (InfiniteCareExport2.Course_Templates ct in cro2.course_templates)
            {
                if(ct.enrollments_count > 0)
                {
                    //Get the enrollment data
                    Enrollment[] enr = await Processor.getEnrollments("https://" + txtDomain.Text + "-acc.bridgeapp.com", txtEnd.Text, txtStart.Text, ct.id.ToString());


                    if(enr == null)
                    {
                        //skip because there are no enrollments! :)
                    }
                    else
                    {
                        foreach (Enrollment en in enr)
                        {
                            CustomFieldsRootobject cfro = new CustomFieldsRootobject();
                            User usr = new User();
                            cfro = await Processor.getUserCustomFields(txtSubURL.Text, en.links.learner.id.ToString());


                            if(cfro == null)
                            {
                                //skip
                            }
                            else
                            {

                                string firstname = cfro.users[0].first_name?.ToString();
                                string lastname = cfro.users[0].last_name?.ToString();
                                string fullname = firstname + " " + lastname;
                                string uid = cfro.users[0].uid.ToString();
                                string completed_at = en.completed_at?.ToString();
                                string expires_at = en.expires_at?.ToString();
                                string end_at = en.end_at?.ToString();

                                if(!string.IsNullOrEmpty(completed_at))
                                {
                                    DateTime completed = DateTime.ParseExact(completed_at.Substring(0,10), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                                    DateTime dt = DateTime.ParseExact(txtStart.Text.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                                    int gt = DateTime.Compare(dt, completed);
                                    //if gt > 0, then include in list

                                    DateTime end =DateTime.ParseExact(txtEnd.Text.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                                    if(gt < 0)
                                    {
                                        list.Add(new FileOutput
                                        {
                                            user_id = en.links.learner.id.ToString(),
                                            uid = uid,
                                            learnable_id = en.id.ToString(),
                                            enrolled = en.created_at.ToString(),
                                            due = end_at,
                                            started = en.created_at.ToString(),
                                            completed = completed_at,
                                            expiry = expires_at,
                                            score = en.score.ToString(),
                                            learnable_group = ""
                                        });
                                    }

                                }


                            }


                        }
                    }

                }
            }


            if (list.Count > 0)
            {
                logger.Info("Retrieved " + list.Count.ToString() + " records.");

                string fileName = "Learning_Records-" + DateTime.Now.ToString("yyyyMMddHHmmss").Replace(" / ", "-") + ".xlsx";
                string StagingPath = @ConfigurationManager.AppSettings["StagingFolder"];
                string ProcessedPath = @ConfigurationManager.AppSettings["ProcessedFolder"];


                using (ExcelPackage excelpackage = new ExcelPackage())
                {
                    //Create an Excel worksheet
                    ExcelWorksheet worksheet = excelpackage.Workbook.Worksheets.Add("Export");

                    worksheet.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Medium16);

                    FileInfo fi = new FileInfo(StagingPath + fileName);
                    excelpackage.SaveAs(fi);
                    logger.Info("Saved file to: " + StagingPath + fileName);
                }

            }
        }
    }
}
