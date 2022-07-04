using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VBToCSharp
{
    public partial class MainForm : Form
    {
        private List<List<string>> cReplace = new List<List<string>>();
        private List<List<string>> cBetween = new List<List<string>>();
        private List<List<string>> cPull = new List<List<string>>();
        private List<List<string>> cPush = new List<List<string>>();

        public MainForm()
        {
            InitializeComponent();
            //Teste5
            //Replace
            cReplace.Add(new List<string> { "Imports ", "using " });
            cReplace.Add(new List<string> { "Public ", "public " });
            cReplace.Add(new List<string> { "Private ", "private " });
            cReplace.Add(new List<string> { "Protected ", "protected " });
            cReplace.Add(new List<string> { "Partial ", "partial " });
            cReplace.Add(new List<string> { " Class ", " class " });
            
            cReplace.Add(new List<string> { " ReadOnly ", " readonly " });
            cReplace.Add(new List<string> { " WriteOnly ", " " });
            

            cReplace.Add(new List<string> { " Const ", " const " });

            cReplace.Add(new List<string> { " Event ", " event " });
            cReplace.Add(new List<string> { " RaiseEvent ", " " });


            cReplace.Add(new List<string> { "= My.Settings.", "= Settings.Default." });


            cReplace.Add(new List<string> { "Partial Public ", "public partial " });

            cReplace.Add(new List<string> { "End Class", "}" });
            cReplace.Add(new List<string> { "End Function", "}" });
            cReplace.Add(new List<string> { "End Sub", "}" });
            cReplace.Add(new List<string> { "End Property", "}" });
            cReplace.Add(new List<string> { "End If", "}" });
            cReplace.Add(new List<string> { "End Try", "}" });
            cReplace.Add(new List<string> { "End Get", "}" });
            cReplace.Add(new List<string> { "End Set", "}" });
            cReplace.Add(new List<string> { "End While", "}" });

            cReplace.Add(new List<string> { "Exit For", "break;" });
            cReplace.Add(new List<string> { "Exit Sub", "break;" });


            cReplace.Add(new List<string> { " Get" + Environment.NewLine, " get{" + Environment.NewLine });

            cReplace.Add(new List<string> { "#End Region", "#endregion" });
            cReplace.Add(new List<string> { "#Region ", "#region " });

            cReplace.Add(new List<string> { Environment.NewLine + "    Inherits ", " Inherits " });
            cReplace.Add(new List<string> { " Inherits ", " : " });
            //cReplace.Add(new List<string> { " Sub ", " void " });
            //cReplace.Add(new List<string> { " Not ", " !" });
            cReplace.Add(new List<string> { " True", " true" });
            cReplace.Add(new List<string> { "(True)", "(true)" });
            cReplace.Add(new List<string> { " False", " false" });
            cReplace.Add(new List<string> { "(False)", "(false)" });
            cReplace.Add(new List<string> { "Return ", "return " });
            cReplace.Add(new List<string> { " In ", " in " });
            cReplace.Add(new List<string> { " New ", " new " });
            cReplace.Add(new List<string> { "(New ", "(new " });
            cReplace.Add(new List<string> { " DbDataReader", " IDataReader" });
            cReplace.Add(new List<string> { " Data.SqlClient.", " " });
            cReplace.Add(new List<string> { " SqlClient.", " " });

            cReplace.Add(new List<string> { " Overrides ", " override " });
            cReplace.Add(new List<string> { " <> ", " != " });

            cReplace.Add(new List<string> { " AddHandler ", " " });
            cReplace.Add(new List<string> { ", AddressOf ", " += " });


            cReplace.Add(new List<string> { " Is Nothing", " == null" });
            cReplace.Add(new List<string> { " Nothing", " null" });
            cReplace.Add(new List<string> { "(Nothing", "(null" });
            cReplace.Add(new List<string> { " String.", " string." });
            cReplace.Add(new List<string> { "(String.", "(string." });
            cReplace.Add(new List<string> { "IsDBNull(", "Convert.IsDBNull(" });
            cReplace.Add(new List<string> { " Not Convert.IsDBNull", " !Convert.IsDBNull" });

            cReplace.Add(new List<string> { ".Tables(0)", ".Tables[0]" });
            cReplace.Add(new List<string> { ".DataSource(0)", ".DataSource[0]" });
            cReplace.Add(new List<string> { ".(i)", "[i]" });
            cReplace.Add(new List<string> { "(i)", "[i]" });
            cReplace.Add(new List<string> { ")(0)", ")[0]" });


            cReplace.Add(new List<string> { "CInt(", "Convert.ToInt32(" });
            cReplace.Add(new List<string> { "CDate(", "Convert.ToDateTime(" });


            cReplace.Add(new List<string> { ".ToUpper" + Environment.NewLine, ".ToUpper()" + Environment.NewLine });
            cReplace.Add(new List<string> { ".Trim" + Environment.NewLine, ".Trim()" + Environment.NewLine });
            cReplace.Add(new List<string> { ".toString" + Environment.NewLine, ".ToString()" + Environment.NewLine });
            cReplace.Add(new List<string> { ".ToString.", ".ToString()." });
            cReplace.Add(new List<string> { ".ToString)", ".ToString())" });
            cReplace.Add(new List<string> { ".Read()", ".Read" });
            cReplace.Add(new List<string> { ".Read", ".Read()" });

            cReplace.Add(new List<string> { "new ListItem(\" \", -1)", "new ListItem(\" \", \"-1\")" });



            cReplace.Add(new List<string> { " Me.", " " });
            cReplace.Add(new List<string> { "(Me.", "(" });
            cReplace.Add(new List<string> { "'Me.", "'" });

            cReplace.Add(new List<string> { " Environment.NewLine & _", " Environment.NewLine +" });
            cReplace.Add(new List<string> { " & _", " + Environment.NewLine +" });
            cReplace.Add(new List<string> { " & Environment.NewLine", " + Environment.NewLine" });


            cReplace.Add(new List<string> { "\" & ", "\" + " });
            cReplace.Add(new List<string> { " & \"", " + \"" });

            cReplace.Add(new List<string> { "  '", "  //'" });

            //cReplace.Add(new List<string> { " As New ", " = new " });
            cReplace.Add(new List<string> { " As Int16", " As short" });
            cReplace.Add(new List<string> { " As Int32", " As int" });
            cReplace.Add(new List<string> { " As Integer", " As int" });
            cReplace.Add(new List<string> { " As String", " As string" });
            cReplace.Add(new List<string> { " As Date" + Environment.NewLine, " As DateTime" + Environment.NewLine });
            cReplace.Add(new List<string> { " As datetime", " As DateTime" });
            cReplace.Add(new List<string> { " As Boolean", " As bool" });
            cReplace.Add(new List<string> { " As Object", " As object" });


            cReplace.Add(new List<string> { "Of Int16", "Of short" });
            cReplace.Add(new List<string> { "Of Int32", "Of int" });
            cReplace.Add(new List<string> { "Of Integer", "Of int" });
            cReplace.Add(new List<string> { "Of String", "Of string" });


            cReplace.Add(new List<string> { " Date ", " DateTime " });
            cReplace.Add(new List<string> { " Date.", " DateTime." });
            cReplace.Add(new List<string> { "(Date.", "(DateTime." });


            cReplace.Add(new List<string> { "ElseIf ", "}else if(" });
            cReplace.Add(new List<string> { "If ", "if(" });
            cReplace.Add(new List<string> { "Else" + Environment.NewLine, "}else{" + Environment.NewLine });
            cReplace.Add(new List<string> { " Then" + Environment.NewLine, "){" + Environment.NewLine });
            //cReplace.Add(new List<string> { " Then ", ") " });

            cReplace.Add(new List<string> { "Next" + Environment.NewLine, "}" + Environment.NewLine });
            //cReplace.Add(new List<string> { "Optional ", "" });


            cReplace.Add(new List<string> { "Try" + Environment.NewLine, "try{" + Environment.NewLine });
            cReplace.Add(new List<string> { "Catch ex As Exception", "}catch(Exception ex){" });

            cReplace.Add(new List<string> { " ofn.", " oFn." });
            cReplace.Add(new List<string> { " ofn = new ", " oFn." });
            


            //cReplace.Add(new List<string> { "", "" });

            //Pull
            cPull.Add(new List<string> { " Property ", Environment.NewLine, "() As ", Environment.NewLine, " ", "{", "", "1" });
            cPull.Add(new List<string> { " Property ", Environment.NewLine, " As ", Environment.NewLine, " ", "{", "", "1" });
            cPull.Add(new List<string> { " Property ", Environment.NewLine, "()", Environment.NewLine, " string", "{", "", "1" });
            cPull.Add(new List<string> { " Function ", Environment.NewLine, ") As ", Environment.NewLine, " ", "){", "", "1" });
            //cPull.Add(new List<string> { "if(", "){", " = ", "){", "if(", " == ", "){", "0" });
            cPull.Add(new List<string> { "For Each ", " in ", " As ", " in ", "For Each ", "", "", "1" });

            cPull.Add(new List<string> { "Optional ByVal ", " = ", " As ", " = ", "", "", "", "1" });
            //cPull.Add(new List<string> { "ByVal ", ",", " As ", ",", "", "", "", "1" });
            
            cPull.Add(new List<string> { "ByVal ", ",", " As ", ",", "", "", "", "1" });
            cPull.Add(new List<string> { "ByVal ", ")", " As ", ")", "", "", "", "1" });
            cPull.Add(new List<string> { "ByRef ", ")", " As ", ")", "", "", "", "1" });

            cPull.Add(new List<string> { "Dim ", " = ", " As ", " = ", "", "", "", "1" });
            cPull.Add(new List<string> { "Dim ", "()", " As New ", "()", "", " = new ", "", "0" });
            cPull.Add(new List<string> { "Dim ", Environment.NewLine, " As New ", Environment.NewLine, "", " = new ", "()", "0" });
            cPull.Add(new List<string> { "Dim ", Environment.NewLine, " As ", Environment.NewLine, "", "", "", "1" });

            cPull.Add(new List<string> { "Private ", "()", " As New ", "()", "private ", " = new ", "", "0" });
            cPull.Add(new List<string> { "Private ", Environment.NewLine, " As New ", Environment.NewLine, "private ", " = new ", "()", "0" });
            cPull.Add(new List<string> { "Private ", " = ", " As ", " = ", "private ", "", "", "1" });
            cPull.Add(new List<string> { "Private ", Environment.NewLine, " As ", Environment.NewLine, "private ", "", "", "1" });

            cPull.Add(new List<string> { " For ", " = ", " As ", " = ", " for ", "", "", "1" });

            cPull.Add(new List<string> { " CType(", ").", ", ", ").", " CType(", "", "", "1" });
            cPull.Add(new List<string> { " CType(", ")" + Environment.NewLine, ", ", ")" + Environment.NewLine, " CType(", "", "", "1" });

            cPull.Add(new List<string> { " Handles", Environment.NewLine, " ", Environment.NewLine, " Handles ", "+= ", "", "0" });

            //###PUSH
            cPush.Add(new List<string> { " For int", " To ", " = ", "< ", " for int", " = ", ";", "0" });
            cPush.Add(new List<string> { " For int", Environment.NewLine, " = ", "++" + Environment.NewLine, " for ", " = ", ";", "0" });

            cPush.Add(new List<string> { " For short", " To ", " = ", "< ", " for short", " = ", ";", "0" });
            cPush.Add(new List<string> { " For short", Environment.NewLine, " = ", "++" + Environment.NewLine, " for ", " = ", ";", "0" });

            //cPull.Add(new List<string> { "For Each ", " in ", " As ", " in ", "For Each ", "", "", "1" });

            //###Between
            //cBetween.Add(new List<string> { "List(Of ", "))", "List<", ">>", "0" });
            cBetween.Add(new List<string> { " class ", Environment.NewLine, " class ", "{" + Environment.NewLine, "0" });
            cBetween.Add(new List<string> { "List(Of ", ")", "List<", ">", "0" });
            cBetween.Add(new List<string> { "= New List<", ">" + Environment.NewLine, "= new List<", ">()" + Environment.NewLine, "0" });


            cBetween.Add(new List<string> { " Set(", ")" + Environment.NewLine, " set{", Environment.NewLine, "1" });
            cBetween.Add(new List<string> { " Or Not ", " = ", " || ", " != ", "0" });
            cBetween.Add(new List<string> { " And Not ", " = ", " && ", " != ", "0" });
            cBetween.Add(new List<string> { "(Not ", " = ", "(", " != ", "0" });
            cBetween.Add(new List<string> { "(Not ", " == null", "(", " != null", "0" });
            cBetween.Add(new List<string> { " Not ", " == null", " ", " != null", "0" });
            cBetween.Add(new List<string> { "(Not ", "){", "(!", "){", "0" });


            //cBetween.Add(new List<string> { "(Not Convert.IsDBNull", " = ", "(!Convert.IsDBNull", " != ", "0" });

            cBetween.Add(new List<string> { "IIf(", ", ", "IIf(", " ? ", "0" });
            cBetween.Add(new List<string> { "IIf(", ", ", "IIf(", " : ", "0" });
            cBetween.Add(new List<string> { "IIf(", " = ", "(", " == ", "0" });
            cBetween.Add(new List<string> { "IIf(", " == ", "(", " == ", "0" });
            cBetween.Add(new List<string> { "IIf(", " <= ", "(", " <= ", "0" });

            cBetween.Add(new List<string> { " Then ", " = ", " Then ", " xxx= ", "0" });
            cBetween.Add(new List<string> { "if(", " = ", "if(", " == ", "0" });
            cBetween.Add(new List<string> { "if(", " = ", "if(", " == ", "0" });
            cBetween.Add(new List<string> { "if(", " = ", "if(", " == ", "0" });
            cBetween.Add(new List<string> { " Then ", " xxx= ", ") ", " = ", "0" });

            cBetween.Add(new List<string> { "For Each ", Environment.NewLine, "foreach(", "){" + Environment.NewLine, "0" });
            cBetween.Add(new List<string> { " For ", Environment.NewLine, " for (", "){" + Environment.NewLine, "0" });

            cBetween.Add(new List<string> { " Sub ", ")" + Environment.NewLine, " void ", "){" + Environment.NewLine, "0" });
            cBetween.Add(new List<string> { ".Item(", "\")" + Environment.NewLine, ".Item(", "\").ToString()" + Environment.NewLine, "0" });
            cBetween.Add(new List<string> { ".Item(", ")", "[", "]", "0" });
            cBetween.Add(new List<string> { " While ", Environment.NewLine, " while(", "){" + Environment.NewLine, "0" });

            cBetween.Add(new List<string> { " Session(", ")", " Session[", "]", "0" });
            cBetween.Add(new List<string> { "(Session(", ")", "(Session[", "]", "0" });

            //cBetween.Add(new List<string> { " Handles ", Environment.NewLine, "{" + Environment.NewLine + "        Handles ", Environment.NewLine, "0" });
            cBetween.Add(new List<string> { " Handles ", ".", " Handles ", "_", "0" });
            cBetween.Add(new List<string> { " Handles ", ".", " Handles ", "_", "0" });
            cBetween.Add(new List<string> { " Handles ", "_", " Handles ", ".", "0" });
            //cBetween.Add(new List<string> { " Handles ", Environment.NewLine, " ", Environment.NewLine, "0" });

            cBetween.Add(new List<string> { " CType(", " ", " ((", ")", "0" });

            cBetween.Add(new List<string> { "(dr(", ")", "(dr[", "]", "0" });
            cBetween.Add(new List<string> { " dr(", ")", " dr[", "]", "0" });
            cBetween.Add(new List<string> { "private ", " const ", "private const ", " ", "0" });
            cBetween.Add(new List<string> { "public ", " const ", "public const ", " ", "0" });
            cBetween.Add(new List<string> { " event ", "()", " event ", "", "0" });

            cBetween.Add(new List<string> { ".ConfigurationManager.AppSettings(", ")", ".ConfigurationManager.AppSettings[", "]", "0" });
            


            cBetween.Add(new List<string> { Environment.NewLine, "'", Environment.NewLine, "//'", "2" });
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            txtInput.Focus();

            if (txtInput.Text.Length > 0)
            {
                string buffer = txtInput.Text + Environment.NewLine;

                setClassConstructor(ref buffer);

                #region cReplace
                foreach (List<string> item in cReplace)
                {
                    buffer = Regex.Replace(buffer, Regex.Escape(item[0]), item[1], RegexOptions.IgnoreCase);
                }
                #endregion

                #region cPull
                foreach (List<string> item in cPull)
                {
                    string cStartPat = item[0];
                    string cEndPat = item[1];

                    string pattern = Regex.Escape(cStartPat) + "(.*?)" + Regex.Escape(cEndPat);
                    //Match result = 

                    foreach (Match result in Regex.Matches(buffer, pattern, RegexOptions.IgnoreCase))
                    {
                        if (result.Success)
                        {
                            string cExtracted = result.Groups[1].ToString() + item[3];

                            string pattern2 = Regex.Escape(item[2]) + "(.*?)" + Regex.Escape(item[3]);
                            Match result2 = Regex.Match(cExtracted, pattern2, RegexOptions.IgnoreCase);

                            if (result2.Success)
                            {
                                string cExtracted2 = result2.Groups[1].ToString();

                                string strOld = item[0] + cExtracted;

                                //cExtracted = cExtracted.Replace(item[2], item[4]);
                                //cExtracted = cExtracted.Replace(cExtracted2, item[5]);

                                cExtracted = Regex.Replace(cExtracted, Regex.Escape(item[2]), item[5], RegexOptions.IgnoreCase);

                                if (item[7] == "1")
                                {
                                    cExtracted = Regex.Replace(cExtracted, Regex.Escape(cExtracted2), item[6], RegexOptions.IgnoreCase);
                                }
                                else if (item[7] == "0")
                                {
                                    cExtracted = Regex.Replace(cExtracted, Environment.NewLine, item[6] + Environment.NewLine, RegexOptions.IgnoreCase);
                                }

                                string strNew = item[4] + cExtracted2 + " " + cExtracted;

                                //buffer = buffer.Replace(strOld, strNew);
                                buffer = Regex.Replace(buffer, Regex.Escape(strOld), strNew, RegexOptions.IgnoreCase);
                            }
                        }
                    }
                }
                #endregion

                #region cPush
                foreach (List<string> item in cPush)
                {
                    string cStartPat = item[0];
                    string cEndPat = item[1];

                    string pattern = Regex.Escape(cStartPat) + "(.*?)" + Regex.Escape(cEndPat);

                    foreach (Match result in Regex.Matches(buffer, pattern, RegexOptions.IgnoreCase))
                    {
                        if (result.Success)
                        {
                            string cExtracted = result.Groups[0].ToString();

                            string pattern2 = Regex.Escape(item[0]) + "(.*?)" + Regex.Escape(item[2]);
                            Match result2 = Regex.Match(cExtracted, pattern2, RegexOptions.IgnoreCase);

                            if (result2.Success)
                            {
                                string cExtracted2 = result2.Groups[1].ToString();

                                string strOld = cExtracted;



                                if (item[7] == "1")
                                {
                                    cExtracted = Regex.Replace(cExtracted, Regex.Escape(item[1]), cExtracted2, RegexOptions.IgnoreCase);
                                }
                                if (item[7] == "0")
                                {
                                    cExtracted = Regex.Replace(cExtracted, Regex.Escape(item[1]), item[6] + cExtracted2, RegexOptions.IgnoreCase);
                                }

                                string strNew = cExtracted + item[3];

                                //buffer = buffer.Replace(strOld, strNew);
                                buffer = Regex.Replace(buffer, Regex.Escape(strOld), strNew, RegexOptions.IgnoreCase);
                            }
                        }
                    }
                }
                #endregion

                #region cBetween
                foreach (List<string> item in cBetween)
                {
                    string cStartPat = item[0];
                    string cEndPat = item[1];

                    string pattern = Regex.Escape(cStartPat) + "(.*?)" + Regex.Escape(cEndPat);
                    //Match result = Regex.Match(buffer, pattern, RegexOptions.IgnoreCase);

                    foreach (Match result in Regex.Matches(buffer, pattern, RegexOptions.IgnoreCase))
                    {
                        if (result.Success)
                        {
                            string cExtracted = result.Groups[1].ToString();
                            //cExtracted = Regex.Replace(cExtracted, Regex.Escape(item[0]), item[2], RegexOptions.IgnoreCase);

                            //buffer = Regex.Replace(buffer, Regex.Escape(item[0]), item[2], RegexOptions.IgnoreCase);

                            string strOld = item[0] + cExtracted + item[1];

                            string strNew = string.Empty;
                            if (item[4] == "0") { strNew = item[2] + cExtracted + item[3]; }
                            if (item[4] == "1") { strNew = item[2] + item[3]; }
                            if (item[4] == "2" && cExtracted.Trim() == string.Empty) { strNew = item[2] + item[3]; }

                            if (strNew != string.Empty)
                            {
                                //buffer = buffer.Replace(strOld, strNew);
                                buffer = Regex.Replace(buffer, Regex.Escape(strOld), strNew, RegexOptions.IgnoreCase);
                            }
                        }
                    }
                }
                #endregion

                #region commas
                string patternx = "(.*?)" + Environment.NewLine;
                foreach (Match result in Regex.Matches(buffer, patternx, RegexOptions.IgnoreCase))
                {
                    if (result.Success)
                    {
                        string cExtracted = result.Groups[1].ToString();
                        if (cExtracted.Length > 1)
                        {
                            char lastChar = cExtracted[cExtracted.Length - 1];
                            if (lastChar != ';' && lastChar != '{' && lastChar != '}' && lastChar != '+' && lastChar != ' ')
                            {
                                buffer = buffer.Replace(cExtracted + Environment.NewLine, cExtracted + ";" + Environment.NewLine);
                                //buffer = buffer.Replace(";;", ";");
                            }
                        }
                    }
                }
                #endregion

                buffer = buffer.Replace(" Or ", " || ");
                buffer = buffer.Replace(" And ", " && ");

                buffer = buffer.Replace(" IIf(", " (");
                buffer = buffer.Replace(" Sub ", " void ");

                buffer = buffer.Replace("sender As object", "object sender");
                buffer = buffer.Replace("e As EventArgs", "EventArgs e");

                buffer = buffer.Replace("CarregaGradePaginacao[i]", "CarregaGradePaginacao(i)");

                setHandles(ref buffer);


                txtOutput.Text = buffer;
                lblInfo.Text = "Texto Convertido!";
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtInput.Focus();
            if (txtOutput.Text.Length > 0)
            {
                Clipboard.SetText(txtOutput.Text);
                lblInfo.Text = "Texto Copiado!";
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A) txtInput.SelectAll();
        }

        private void txtOutput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A) txtOutput.SelectAll();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Focus();
            txtInput.Text = txtOutput.Text = lblInfo.Text = string.Empty;
        }

        //Get and Set ClassName Constructor
        private void setClassConstructor(ref string buffer)
        {
            string className = string.Empty;

            //Get ClassName
            {
                string pattern = Regex.Escape("Public Class ") + "(.*?)" + Regex.Escape(" ");
                Match result = Regex.Match(buffer, pattern, RegexOptions.IgnoreCase);
                if (result.Success)
                {
                    className = result.Groups[1].ToString();
                }
                else
                {
                    pattern = Regex.Escape("Public Class ") + "(.*?)" + Regex.Escape(Environment.NewLine);
                    result = Regex.Match(buffer, pattern, RegexOptions.IgnoreCase);
                    if (result.Success)
                    {
                        className = result.Groups[1].ToString();
                    }
                }
            }

            //Replace Sub New for Class Name
            if (!string.IsNullOrEmpty(className))
            {
                buffer = buffer.Replace(" Public Sub New()", " Public Sub " + className + "()");
            }

        }

        //Get Linked Functions
        private void setHandles(ref string buffer)
        {
            string HandlesBufferHead = Environment.NewLine + "        //OnLoad" + Environment.NewLine;
            string HandlesBuffer = string.Empty;

            string pattern = Regex.Escape(" Handles ") + "(.*?)" + Regex.Escape(Environment.NewLine);

            //Get All Handles
            foreach (Match result in Regex.Matches(buffer, pattern, RegexOptions.IgnoreCase))
            {
                if (result.Success)
                {
                    string cExtracted = result.Groups[1].ToString();
                    HandlesBuffer += "        " + cExtracted + Environment.NewLine;
                    buffer = buffer.Replace(result.Groups[0].ToString(), "{" + Environment.NewLine);
                }
            }

            if (HandlesBuffer != string.Empty)
            {
                HandlesBuffer = HandlesBufferHead + HandlesBuffer;
                //Insert in Page_Load
                pattern = Regex.Escape(" Page_Load(") + "(.*?)" + Regex.Escape("{" + Environment.NewLine);

                foreach (Match result in Regex.Matches(buffer, pattern, RegexOptions.IgnoreCase))
                {
                    if (result.Success)
                    {
                        string cExtracted = result.Groups[0].ToString();
                        buffer = buffer.Replace(cExtracted, cExtracted + HandlesBuffer + Environment.NewLine + Environment.NewLine);
                        return;
                    }
                }

                //If Page_Load not found add to final text
                buffer += HandlesBuffer + Environment.NewLine + Environment.NewLine;
            }

            //return Environment.NewLine + Environment.NewLine + HandlesBuffer;
        }
    }
}
