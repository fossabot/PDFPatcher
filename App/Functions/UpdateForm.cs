using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using PDFPatcher.Common;
using PDFPatcher.Properties;

namespace PDFPatcher.Functions;

public partial class UpdateForm : Form
{
    private WebClient _UpdateChecker;

    public UpdateForm()
    {
        InitializeComponent();
        this.SetIcon(Resources.CheckUpdate);
        Load += (_, _) =>
        {
            CheckNewVersion();
            int i = AppContext.CheckUpdateInterval;
            _CheckUpdateIntervalBox.Select(i switch
            {
                7 => 0,
                14 => 1,
                30 => 2,
                _ => 3
            });
        };
        FormClosed += (_, _) => { _UpdateChecker?.Dispose(); };
        _HomePageButton.Click += (_, _) => { CommonCommands.VisitHomePage(); };
        _DownloadButton.Click += (_, _) => { Process.Start(_DownloadButton.Tag.ToString()); };
        _CheckUpdateIntervalBox.SelectedIndexChanged += (_, _) =>
        {
            AppContext.CheckUpdateInterval = _CheckUpdateIntervalBox.SelectedIndex switch
            {
                0 => 7,
                1 => 14,
                2 => 30,
                _ => int.MaxValue
            };
            if (AppContext.CheckUpdateInterval != int.MaxValue)
            {
                AppContext.CheckUpdateDate = DateTime.Today + TimeSpan.FromDays(AppContext.CheckUpdateInterval);
            }
        };
    }

    private void CheckNewVersion()
    {
        _UpdateChecker = new WebClient();
        _InfoBox.AppendLine("Checking for a new version, please wait...");
        _UpdateChecker.DownloadDataCompleted += (_, args) =>
        {
            _InfoBox.Clear();
            if (args.Error != null)
            {
                _InfoBox.AppendText("Failed to check new version: " + args.Error.Message);
                goto Exit;
            }

            try
            {
                XmlDocument x = new();
                x.Load(new MemoryStream(args.Result));
                CheckResult(x);
            }
            catch (Exception)
            {
                FormHelper.ErrorBox("The format of the version information file is incorrect, please try again later.");
            }

        Exit:
            _UpdateChecker.Dispose();
            _UpdateChecker = null;
        };
        _UpdateChecker.DownloadDataAsync(new Uri(Constants.AppUpdateFile));
    }

    private void CheckResult(XmlDocument x)
    {
        XmlElement r = x.DocumentElement;
        if (r is not { Name: Constants.AppEngName })
        {
            _InfoBox.SelectionColor = Color.Red;
            _InfoBox.AppendLine("The format of the version information file is incorrect, please try again later.");
            return;
        }

        string v = r.GetAttribute("version");
        string d = r.GetAttribute("date");
        string u = r.GetAttribute("url");
        XmlNode c = r.SelectSingleNode("content");
        if (new Version(ProductVersion) < new Version(r.GetAttribute("version")))
        {
            _InfoBox.SelectionColor = Color.Blue;
            _InfoBox.AppendLine(string.Concat("Found a new version: ", v, " ", d));
            _InfoBox.AppendLine(c.InnerText);
            _InfoBox.SelectionStart = 0;
            if (u.Length <= 0)
            {
                return;
            }

            _DownloadButton.Enabled = true;
            _DownloadButton.Tag = u;
        }
        else
        {
            _InfoBox.AppendLine(string.Join("\n", "No new version found.", "The version published on the server is: ",
                v + " " + d));
        }
    }
}
