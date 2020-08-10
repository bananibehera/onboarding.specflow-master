using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.Helpers
{
    public class ConstantHelpers
    {
        //Base Url
        public static string Url = "http://localhost:5000";

        public static string LevelFluent = "Fluent";
        public static string LevelBasic = "Basic";

        public static string Xpath_Fluent = "//td[contains(.,'French')]";

        public static string Country_College = "New Zealand";
        public static string Year_Grad = "2009";
        public static string Tile = "B.Tech";
        //ScreenshotPath
        //public static string ScreenshotPath = @"C:\Priyabrata\Ruby\Industry Connect\MarsQA\onboarding.specflow-master\MarsQA-1\TestReports\Screenshots\";
        public static string ScreenshotPath = @"MarsQA-1\TestReports\Screenshots\";
        //ExtentReportsPath
        public static string ReportsPath = @"MarsQA-1\TestReports\Test_Files\Report\";

        //ReportXML Path
        public static string ReportXMLPath = @"\MarsQA-1\TestReports\Test_Files\ReportXML\";
    }
}