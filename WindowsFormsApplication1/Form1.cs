using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int successfulCount = 0;
        int pendingCount = 0;
        int failedCount = 0;
        int notPerformedCount = 0;
        private StringBuilder output = new StringBuilder();
        private StringBuilder compareBuilder = new StringBuilder();
        string runNumber = "0";
        string[] featureStrings = new string[] {"Acceptance", "ActivateFeatureToggles", "BVT", "Comprehensive", "Cork", "Feature", "Regression", "SingleThread", "PendingDevelopment", "Workflow"};
        string tableHeader = "<table border='1' style='width: 75%;border-collapse: collapse;border-color: #afafaf;'><tr><td style='width:10%;'><strong>Name</strong></td> " +
                "<td style='width:3%; text-align: center;'><strong># Failures</strong> </td> " +
                "<td style='width:5%; text-align: center;'><strong># Not Performed</strong> </td> " +
                "<td style='width:3%; text-align: center;'> <strong>Link</strong> </td>" +
                "<td style='width:3%; text-align: center;'> <strong>Screenshot</strong> </td>" +
                "<td style='width:3%; text-align: center;'> <strong>Checked</strong> </td>" +
                "<td style='width:30%; text-align: center;'> <strong>Notes</strong> </td></tr>";

        private string jQueryScriptString = "<script src=\"https://code.jquery.com/jquery-2.2.3.js\">}) </script><body><script>" +
                                            @"$(document).ready(function(){
                                                var blueBg = 'rgb(178, 204, 247)';
                                                var orangeBg = 'rgb(247, 163, 111)';
                                                var grayBg = 'rgb(225, 227, 232)';

	                                            $('.results:not(:last)').remove();

                                                    var checkboxValues = JSON.parse(localStorage.getItem('checkboxValues')) || {}; 
	
	                                            $.each(checkboxValues, function(key, value)
                                                {
		                                            $('input#' + key).prop('checked', value);

                                                    if (value)
                                                    {
			                                            $('tr#' + key).css({ backgroundColor: blueBg});
                                                    }                                                   
                                                });

                                                //attempts to get all noteValues from local storage, or creates an empty array if none
												var noteValues = JSON.parse(localStorage.getItem('noteValues')) || {}; 
												
												//loops through each noteValues and fills in previously set vals
												$.each(noteValues, function(key, value)
                                                {
		                                            $('input#' + key).val(value);                                                 
                                                });
												
												//on each text change, get the current val and store to noteValues ID
												$(':text').on('change', function()
                                                {
		                                            $(':text').each(function(){
                                                        noteValues[this.id] = $(this).val();
                                                        });
                                                        localStorage.setItem('noteValues', JSON.stringify(noteValues));
                                                });

                                                    $('td[colspan = 6]').find('p').hide();
													
													$('tr.row').click(function(event) {
                                                        event.stopPropagation();
                                                        var $target = $(event.target);
														if ( $target.closest('td').attr('colspan') > 1 ) {
															$target.slideUp();
                                                            } else {
															  $target.closest('tr').next().find('p').slideToggle();
                                                            }
                                                     });

	                                            $('tr').click(function()
                                                {
                                                    var color = $(this).css('background-color');

                                                    if (this.id != '')
                                                    {
                                                        if (color != blueBg)
                                                        {
                                                            if (color != orangeBg)
                                                            {
					                                            $(this).css({ backgroundColor: orangeBg});
                                                            }
                                                        }
                                                    }
                                                });

                                                $('tr').dblclick(function() {
												    var color = $(this).css('background-color');

                                                    if (this.id != '' && color === orangeBg) {
                                                        if ($(this).is(':nth-child(odd)')){
     		                                                $(this).removeAttr('style');
                                                        } else {
                                                            $(this).css({ backgroundColor: grayBg});
												        }
                                                    }
												});

	                                            $(':checkbox').on('change', function()
                                                {
		                                            $(':checkbox').each(function(){
                                                        checkboxValues[this.id] = this.checked;
                                                        if (this.checked) {
				                                            $('tr#' + this.id).css({ backgroundColor: blueBg});
                                                            } else {
                                                                var color = $('tr#' + this.id).css('background-color');
                                                                if (color === blueBg){
																	if ($('tr#' + this.id).is(':nth-child(odd)')){
																		$('tr#' + this.id).removeAttr('style')
																		} else {
																			$('tr#' + this.id).css({ backgroundColor: grayBg});
																		}
																	}
																}
                                                            });
                                                        localStorage.setItem('checkboxValues', JSON.stringify(checkboxValues));
                                                        });
                                                    
                                                    var table, rows, switching, i, x, y, loop, shouldSwitch;
														  tables = document.getElementsByTagName('table');
														 
														  for (loop = 0;loop<tables.length; loop++) {
															  switching = true;
															  /*Make a loop that will continue until
															  no switching has been done:*/
															  while (switching) {
																//start by saying: no switching is done:
																switching = false;
																rows = tables[loop].getElementsByTagName('TR');
																/*Loop through all table rows (except the
																first, which contains table headers):*/
																for (i = 1; i< (rows.length - 1); i++) {
																  //start by saying there should be no switching:
																  shouldSwitch = false;
																  /*Get the two elements you want to compare,
																  one from current row and one from the next:*/
																  x = rows[i].getElementsByTagName('TD')[0];
																  y = rows[i + 1].getElementsByTagName('TD')[0];
																  //check if the two rows should switch place:
																  if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
																	//if so, mark as a switch and break the loop:
																	shouldSwitch= true;
																	break;
																  }
                                                                }
																if (shouldSwitch) {
																  /*If a switch has been marked, make the switch
																  and mark that a switch has been done:*/
																  rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
																  switching = true;
																}
															  }
														  	}
                                                        var hide = true;
                                                        $('#button').click(function(){                                                            
                                                            var rows = document.getElementsByClassName('name');
                                                            for (i = 0; i <= (rows.length - 1); i++) {
                                                                var rowID = rows[i].id;
                                                                if (hide) {        
                                                                    if (document.getElementsByName(rowID).length > 1) {
                                                                        $('td.name#' + rowID).parent().show();
                                                                    } else {
                                                                        $('td.name#' + rowID).parent().hide();
                                                                    }
                                                                } else {
                                                                    $('td.name#' + rowID).parent().show();
                                                                }
                                                               }
                                                               hide = !hide;
                                                        })
                                                         }); 
                                                        </script></body> ";


        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            //version.Text = "Version " + Application.ProductVersion;
            
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            output.Append(jQueryScriptString);

        }
       

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
                backgroundWorker1.RunWorkerAsync(files);
            }
        }


        
        private void ParseHtml(String[] files)
        {
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string fileExtension = fileInfo.Extension;
                var currentSuccess = 0;
                var currentFailure = 0;
                var currentPending = 0;
                var currentNotPerformed = 0;
                

                if (file.EndsWith("reports.html") || fileExtension.Equals(""))
                {
                    Debug.WriteLine("Processing " + file);
                    if (Directory.Exists(file))
                    {
                        string[] newDirectories = Directory.GetDirectories(file);
                        string[] newFiles = Directory.GetFiles(file, "*.html");
                        string[] combined = newDirectories.Concat(newFiles).ToArray();

                        ParseHtml(combined);
                    }
                    else
                    {
                        string readerStr = File.ReadAllText(file);
                        Regex regex = new Regex("<tr class=\"totals\">");
                        Match match = regex.Match(readerStr);
                        if (match.Success)
                        {
                            string[] split = regex.Split(readerStr);
                            string totals = split[1];
                            string[] results = {"successful", "pending", "failed", "notPerformed"};
                            foreach (string result in results)
                            {
                                Regex successfulRegex = new Regex("<span class=\"" + result + "\">");
                                Match successfulMatch = successfulRegex.Match(totals);
                                string[] successfulStrings = successfulRegex.Split(totals);
                                string[] successfulSplit = successfulStrings[successfulStrings.Length - 1].Split('<');
                                int count = (successfulMatch.Success
                                    ? Int32.Parse(successfulSplit[0].Replace(",", ""))
                                    : 0);

                                switch (result)
                                {
                                    case "successful":
                                        successfulCount = successfulCount + count;
                                        currentSuccess = count;
                                        break;
                                    case "pending":
                                        pendingCount = pendingCount + count;
                                        currentPending = count;
                                        break;
                                    case "failed":
                                        failedCount = failedCount + count;
                                        currentFailure = count;
                                        break;
                                    case "notPerformed":
                                        notPerformedCount = notPerformedCount + count;
                                        currentNotPerformed = count;
                                        break;
                                }

                            }
                            var initialFileCount = int.Parse(this.fileCountLabel.Text);
                            var newFileCount = ++initialFileCount;
                            this.fileCountLabel.Text = newFileCount.ToString();
                            string[] path = file.Split('\\');
                            StringBuilder sb = new StringBuilder(fileList.Text);
                            sb.Append("\n" + path[path.Length - 3]);
                            this.fileList.Text = sb.ToString();

                        
                            //go through and find failures
                            string[] storySplits = readerStr.Split(new[] {"<td class=\"story failed\">"},
                                StringSplitOptions.None);
                            string[] fileDirectory = file.Split(new[] {"reports.html"}, StringSplitOptions.None);

                            runNumber = path[path.Length - 4];

                            var featureName = path[path.Length - 3];
                            var trimmedFeatureName = featureName.Split('_')[0];

                            output.Append("<div name='"+trimmedFeatureName+"'> <table style='width: 30%; border-spacing: 0 10;'><tr> <td style='font-size: 120%;'><strong>" + featureName + "</strong></td> " +
                                         "<td style='font-size: 120%'><strong>Total Failures: " + currentFailure + "</strong> </td></tr></table>");

                            output.Append(tableHeader);
                            int iteration = 0;
                            foreach (string storySplit in storySplits)
                            {
                                //get failure name
                                string[] storyName = storySplit.Split('<');
                                if (!storyName[0].Trim().Equals(""))
                                {
                                    //get failure count
                                    string[] storyFailureCount =
                                        storySplit.Split(new[] {"<span class=\"failed\">"},
                                            StringSplitOptions.None);
                                    string[] storyFailureCountStr = storyFailureCount[2].Split('<');

                                    //get failure href
                                    string[] storyHref = storySplit.Split(new[] {"<a href=\""},
                                        StringSplitOptions.None);
                                    string[] storyHrefStr = storyHref[2].Split('"');
                                    string storyURL = fileDirectory[0] + storyHrefStr[0];

                                    //get not performed count
                                    Regex notPerformedRegex = new Regex("<span class=\"notPerformed\">");
                                    Match notPerformedMatch = notPerformedRegex.Match(storySplit);
                                    string storyNotPerformedStr;

                                    if (notPerformedMatch.Success)
                                    {
                                        string[] storyNotPerformedCount =
                                            storySplit.Split(new[] {"<span class=\"notPerformed\">"},
                                                StringSplitOptions.None);
                                        string[] storyNotPerformedArray = storyNotPerformedCount[1].Split('<');
                                        storyNotPerformedStr = storyNotPerformedArray[0];
                                    }
                                    else
                                    {
                                        storyNotPerformedStr = "0";
                                    }

                                    string resultDetail = File.ReadAllText(storyURL);
                                    Regex jpgRegex = new Regex(".jpg");
                                    Match jpgMatch = jpgRegex.Match(resultDetail);

                                    Regex resumeJpgRegex = new Regex("resume.jpg");
                                    Match resumeJpgMatch = resumeJpgRegex.Match(resultDetail);

                                    Regex loginFailureRegex = new Regex("x-btn ops-mega-header-icon x-unselectable x-btn-toolbar x-box-item x-toolbar-item x-btn-main-toolbar-medium x-icon-text-left x-btn-icon-text-left x-btn-main-toolbar-medium-icon-text-left");
                                    Match loginFailureMatch = loginFailureRegex.Match(resultDetail);

                                    Regex missingMenuRegex = new Regex("Unable to find menu item");
                                    Match missingMenumatch = missingMenuRegex.Match(resultDetail);

                                    Regex noSuchRegex = new Regex("NoSuchSessionException: no such session");
                                    Match noSuchMatch = noSuchRegex.Match(resultDetail);

                                    string jpgURL;
                                    if (jpgMatch.Success && !resumeJpgMatch.Success)
                                    {
                                        string[] jpgDirectory =
                                            storyURL.Split(new[] { "\\jbehave" },
                                                StringSplitOptions.None);
                                        string[] resultFailure = 
                                            resultDetail.Split(new[] {"\"step failed\""},
                                            StringSplitOptions.None);
                                        string[] jpgFilepath = jpgRegex.Split(resultFailure[1]);
                                        if (jpgFilepath[0].Contains("screenshots"))
                                        {
                                            string[] jpgFileNameSplit = jpgFilepath[0].Split('\\');
                                            string jpgFileName = "\\" + jpgFileNameSplit[jpgFileNameSplit.Length - 4] +
                                                                 "\\" + jpgFileNameSplit[jpgFileNameSplit.Length - 3] +
                                                                 "\\" + jpgFileNameSplit[jpgFileNameSplit.Length - 2] +
                                                                 "\\" + jpgFileNameSplit[jpgFileNameSplit.Length - 1];

                                            jpgURL = "<a href=\"" + jpgDirectory[0] + jpgFileName +
                                                     ".jpg\" target=\"_blank\"> jpeg </a>";
                                        }
                                        else
                                        {
                                        jpgURL = "&nbsp;";
                                        }
                                    }
                                    else
                                    {
                                        jpgURL = "&nbsp;";
                                    }
                                    string storyNameStr = storyName[0].Replace("&", "").Replace(" ", "");
                                    string uniqueId = featureName + storyNameStr;
                                    string alternatingBackground = ((iteration%2 == 0) ? "#e1e3e8" : "");
                                    iteration++;

                                    string finalStoryName = storyName[0];

                                    if (loginFailureMatch.Success)
                                    {
                                        finalStoryName = finalStoryName + " [Login Failure]";
                                    }

                                    if (missingMenumatch.Success)
                                    {
                                        finalStoryName = finalStoryName + " [Missing Menu Item]";
                                    }

                                    if (noSuchMatch.Success)
                                    {
                                        finalStoryName = finalStoryName + " [No Such Session]";
                                    }

                                    output.Append("<lineItemStart><tr style='margin: 0px;background-color: " + alternatingBackground + $";' id=\"id_{ uniqueId }\">" +
                                                    "<td style='width:10%;' class='name' name='"+ storyNameStr +"' id='"+ storyNameStr +"'>" + finalStoryName + "</td>" +
                                                    "<td style='width:3%; text-align: center;'> " + storyFailureCountStr[0] + "</td>" +
                                                    "<td style='width:5%; text-align: center;'> " + storyNotPerformedStr + "</td>" +
                                                    "<td style='width:3%; text-align: center;'>" + "<a href=\"" + storyURL + "\" target=\"_blank\"> html </a></td>" +
                                                    "<td style='width:3%; text-align: center;'>" + jpgURL + "</td>" +
                                                    "<td style='width:3%; text-align: center;'><label style='padding:1% 40%;'> <input type=\"checkbox\" id=\"id_" + uniqueId + "\" style=''></label></td>"+
                                                    "<td style='width:30%; text-align: center;'><input type='text' id=\"id_text_" + uniqueId + "\" style='width: 99%'> </td></tr><lineItemEnd>");

                                }
                            }

                            var currentTotalCount = currentSuccess + currentPending + currentFailure + currentNotPerformed;
                            var currentPercentage = Math.Round((currentTotalCount > 0 ? ((currentSuccess + currentPending) / (double)currentTotalCount) * 100 : 0), 3);

                            output.Append("</table><br><table style='width: 50%'><tr><td><strong>Total: " + currentTotalCount +
                                "</strong></td><td><strong>Success: " + currentSuccess +
                                "</strong></td><td><strong>Pending: " + currentPending +
                                "</strong></td><td><strong>Failures: " + currentFailure +
                                "</strong></td><td><strong>Not Performed: " + currentNotPerformed +
                                "</strong></td><td><strong>Pass: " + currentPercentage + "%" +
                                "</td></strong></tr> </table></div><br><br> -=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- <br><br>");
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!runNumber.Equals("0"))
            {
            var totalCount = successfulCount + pendingCount + failedCount + notPerformedCount;
            var passPercentage =
                Math.Round((totalCount > 0 ? ((successfulCount + pendingCount)/(double) totalCount)*100 : 0), 3);
            var message =
                "<div class='results'><br><br><div style='font-size: 110%'> <strong> <div style='float: left; width:9%;'> Total Overall: </div> <div style='float: left; width:5%;'> " +
                totalCount +
                "</div><br><div style='float: left; width:9%;'> Total Successful: </div> <div style='float: left; width:5%;'>" +
                successfulCount +
                "</div><br><div style='float: left; width:9%;'> Total Pending: </div> <div style='float: left; width:5%;'> " +
                pendingCount +
                "</div><br><div style='float: left; width:9%;'> Total Failed: </div> <div style='float: left; width:5%;'> " +
                failedCount +
                "</div><br><div style='float: left; width:9%;'> Total Not Performed: </div> <div style='float: left; width:5%;'>" +
                notPerformedCount +
                "</div><br><div style='float: left; width:9%;'> Total Pass: </div> <div style='float: left; width:5%;'>" +
                passPercentage + "%</div></strong></div></div>";

            output.Append(message);
            string outputPath = AppDomain.CurrentDomain.BaseDirectory + @"\results_" + runNumber + ".html";

            System.IO.StreamWriter fileWriter = new StreamWriter(outputPath, false);
            fileWriter.Write(output.ToString());
            fileWriter.Close();

            System.Diagnostics.Process.Start(outputPath);
        }

    }

        private void button3_Click(object sender, EventArgs e)
        {
            successfulCount = 0;
            pendingCount = 0;
            failedCount = 0;
            notPerformedCount = 0;
            this.fileCountLabel.Text = "0";
            this.fileList.Text = null;
            runNumber = "0";
            output.Clear();
            output.Append(jQueryScriptString);

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new Action<object>((args) =>
            {
                string[] files = (string[]) args;
                ParseHtml(files);
            }), e.Argument);
 
        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select two results to compare";
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.ShowDialog();
            string[] text = openFileDialog.FileNames;

            if (text.Length >= 2)
            {
                List<String> runList = new List<string>();

                //get the run number for each file to use
                foreach (var result in text)
                {
                    var runNumber = result.Split('_')[1].Split('.')[0];
                    runList.Add(runNumber);
                }


                compareBuilder.Append(jQueryScriptString);
                compareBuilder.Append(
                    "<button type='button' id='button' style='margin: 10% 30% 0px 85%;position:fixed; padding: 15px'>Show/Hide</button>");
                
                foreach (var featureName in featureStrings)
                {
                    bool writeHeader = true;
                    Regex featureDivRegex = new Regex(@"<div name='"+featureName+"'");
                    Regex lineItemStart = new Regex("<lineItemStart>");
                    for (int loop = 0; loop < text.Length; loop++)
                    {
                        //get the file content
                        string fileContent1 = File.ReadAllText(text[loop]);
                        //split the results into the feature name divs
                        string[] tables1 = featureDivRegex.Split(fileContent1);
                        string[] lineItems1 = new string[] { };

                        //check if the file content has the feature div
                        if (featureDivRegex.Match(fileContent1).Success)
                        {
                            //get the end of the feature div
                            string[] featureEnd = tables1[1].Split(new[] { "</div>" }, StringSplitOptions.None);

                            //check if the feature div has any line items
                            if (lineItemStart.Match(featureEnd[0]).Success)
                            {
                                lineItems1 = lineItemStart.Split(featureEnd[0]);
                            }
                        }

                        if (lineItems1.Length > 0 && writeHeader)
                        {
                            compareBuilder.Append("<div name='" + featureName +
                                                  "'> <table style='width: 30%; border-spacing: 0 10;'><tr> <td style='font-size: 120%;'><strong>" +
                                                  featureName + "</strong></td></tr></table>");
                            compareBuilder.Append(tableHeader);
                            writeHeader = false;
                        }

                        for (int lineLoop = 1; lineLoop < lineItems1.Length; lineLoop++)
                        {
                            string[] lineStrings = lineItems1[lineLoop].Split(new[] { "<lineItemEnd>" }, StringSplitOptions.None);
                            compareBuilder.Append(lineStrings[0]);
                        }
                    }
                    compareBuilder.Append("</table></div><br>");



                }
                string comparisonPath = AppDomain.CurrentDomain.BaseDirectory + @"\" + String.Join("_", runList.ToArray()) + "_comparison.html";

                System.IO.StreamWriter fileWriter = new StreamWriter(comparisonPath, false);
                fileWriter.Write(compareBuilder.ToString());
                fileWriter.Close();

                System.Diagnostics.Process.Start(comparisonPath);

            }
        }
    }
}
