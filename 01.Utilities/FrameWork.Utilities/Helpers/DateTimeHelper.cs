using System;
using System.Globalization;

namespace FrameWork.Utilities.Helpers
{
    public class DateTimeHelper
    {
        /// <summary>
        /// این تابع جهت تبدیل تاریخ میلادی به شمسی به کار می رود
        /// </summary>
        /// <param name="S_MiladiDate">تاریخ مورد نظر جهت تبدیل به شمسی</param>
        /// <returns>تاریخ شمسی</returns>
        public static string MiladiToShamsiDate(DateTime S_MiladiDate, bool IncludeTime = false)
        {
            if (S_MiladiDate < Convert.ToDateTime("1753/01/01"))
                return S_MiladiDate.ToString();

            int Year = default;
            int Month = default;
            int Day = default;

            string Y = "";
            string M = "";
            string D = "";

            PersianCalendar PersianCalendarObject = new PersianCalendar();
            Year = PersianCalendarObject.GetYear(S_MiladiDate);
            Month = PersianCalendarObject.GetMonth(S_MiladiDate);
            Day = PersianCalendarObject.GetDayOfMonth(S_MiladiDate);

            Y = Year.ToString();

            if (Month.ToString().Length == 1)
            {
                M = "0" + Month.ToString();
            }
            else
            {
                M = Month.ToString();
            }


            if (Day.ToString().Length == 1)
            {
                D = "0" + Day.ToString();
            }
            else
            {
                D = Day.ToString();
            }

            string RetTime = "";
            if (IncludeTime)
            {
                RetTime = " ";
                if (S_MiladiDate.Hour >= 10)
                    RetTime += S_MiladiDate.Hour.ToString();
                else
                    RetTime += "0" + S_MiladiDate.Hour.ToString();

                if (S_MiladiDate.Minute >= 10)
                    RetTime += ":" + S_MiladiDate.Minute.ToString();
                else
                    RetTime += ":0" + S_MiladiDate.Minute.ToString();

                if (S_MiladiDate.Second >= 10)
                    RetTime += ":" + S_MiladiDate.Second.ToString();
                else
                    RetTime += ":0" + S_MiladiDate.Second.ToString();
            }

            return Y + "/" + M + "/" + D + RetTime;
        }

        /// <summary>
        /// جهت تبدیل ساعت گرینویچ به تهران
        /// </summary>
        /// <param name="S_UTCDate">تاریخ و ساعت میلادی</param>
        /// <returns>تاریخ میلادی و ساعت به منطقه تهران </returns>
        public static DateTime GetDateTimeByLocalTimeZone(DateTime S_UTCDate)
        {
            //به دست آوردن تاریخ شمسی معادل تاریخ ورودی         
            string ShamsiDate = MiladiToShamsiDate(S_UTCDate);

            string MonthStr = ShamsiDate.Substring(5, 2);
            string DayStr = ShamsiDate.Substring(8, 2);

            int Month = Convert.ToInt32(MonthStr);
            int Day = Convert.ToInt32(DayStr);

            int DiffValue = 0;

            //چون از ساعت 00:00 روز دوم فروردین ساعتها یک ساعت جلو کشیده میشود تا پایان روز 30 شهریور اختلاف ساعت ما با گرینویچ 4:30 می باشد و در روز های دیگر 3:30 می باشد

            if (Month == 1 && Day >= 2 || Month >= 2 && Month < 6 || Month == 6 && Day < 31)
                DiffValue = 270 * 60;
            else
                DiffValue = 210 * 60;

            DiffValue -= 18;

            return S_UTCDate.AddSeconds(DiffValue);
        }

        /// <summary>
        /// تبدیل تاریخ و ساعت میلادی به وقت ایران به  ساعت و تاریخ جهانی
        /// </summary>        
        public static DateTime GetDateTimeByUTCDate(DateTime S_IranDate)
        {
            //به دست آوردن تاریخ شمسی معادل تاریخ ورودی         
            string ShamsiDate = MiladiToShamsiDate(S_IranDate);

            string MonthStr = ShamsiDate.Substring(5, 2);
            string DayStr = ShamsiDate.Substring(8, 2);

            int Month = Convert.ToInt32(MonthStr);
            int Day = Convert.ToInt32(DayStr);

            int DiffValue = 0;

            //چون از ساعت 00:00 روز دوم فروردین ساعتها یک ساعت جلو کشیده میشود تا پایان روز 30 شهریور اختلاف ساعت ما با گرینویچ 4:30 می باشد و در روز های دیگر 3:30 می باشد

            if (Month == 1 && Day >= 2 || Month >= 2 && Month < 6 || Month == 6 && Day < 31)
                DiffValue = 270 * 60;
            else
                DiffValue = 210 * 60;

            return S_IranDate.AddSeconds(DiffValue * -1);
        }

        /// <summary>
        /// تبدیل تاریخ شمسی به تاریخ میلادی
        /// </summary>        
        public static DateTime? ShamsiToMiladi(string S_ShamsiDate)
        {
            if (S_ShamsiDate.Trim().Length < 10)
                return null;
            else if (S_ShamsiDate.Trim().Length > 19)
                return null;


            string Year = "";
            string Month = "";
            string Day = "";
            string Hour = "";
            string Minute = "";
            string Seconds = "";
            int Y; int M; int D; int H = 0; int Mi = 0; int S = 0;
            bool WithTime = false;

            if (S_ShamsiDate.Trim().Length == 19 || S_ShamsiDate.Trim().Length == 16)
                WithTime = true;

            Year = S_ShamsiDate.Trim().Substring(0, 4);
            Month = S_ShamsiDate.Trim().Substring(5, 2);
            Day = S_ShamsiDate.Substring(8, 2);

            try { Y = Convert.ToInt32(Year); } catch { return null; }
            try { M = Convert.ToInt32(Month); } catch { return null; }
            try { D = Convert.ToInt32(Day); } catch { return null; }

            if (WithTime)
            {
                Hour = S_ShamsiDate.Trim().Substring(11, 2);
                Minute = S_ShamsiDate.Trim().Substring(14, 2);
                try { Seconds = S_ShamsiDate.Trim().Substring(17, 2); } catch { Seconds = "0"; }

                try { H = Convert.ToInt32(Hour); } catch { return null; }
                try { Mi = Convert.ToInt32(Minute); } catch { return null; }
                try { S = Convert.ToInt32(Seconds); } catch { }

            }

            PersianCalendar PersianCalendarObject = new PersianCalendar();
            return PersianCalendarObject.ToDateTime(Y, M, D, H, Mi, S, 0);

        }

        public static string GetTime(DateTime S_Date)
        {
            string CurrentTime = "";

            if (S_Date.Hour < 10)
                CurrentTime = "0" + S_Date.Hour.ToString();
            else
                CurrentTime = S_Date.Hour.ToString();

            if (S_Date.Minute < 10)
                CurrentTime += ":0" + S_Date.Minute.ToString();
            else
                CurrentTime += ":" + S_Date.Minute.ToString();

            if (S_Date.Second < 10)
                CurrentTime += ":0" + S_Date.Second.ToString();
            else
                CurrentTime += ":" + S_Date.Second.ToString();

            return CurrentTime;
        }

        public static string GetFullTime(int S_Secend)
        {
            string RetValue = "";
            if (S_Secend == 0)
                return "";

            int H = S_Secend / 3600;
            int M = S_Secend % 3600 / 60;
            int S = S_Secend % 3600 % 60;

            if (S_Secend < 60)
                S = S_Secend;

            if (H >= 10)
                RetValue = H.ToString();
            else
                RetValue = "0" + H.ToString();

            if (M >= 10)
                RetValue += ":" + M.ToString();
            else
                RetValue += ":0" + M.ToString();

            if (S >= 10)
                RetValue += ":" + S.ToString();
            else
                RetValue += ":0" + S.ToString();

            return RetValue;
        }

        public static string GetCurrentTime()
        {
            string CurrentTime = "";

            if (DateTime.Now.Hour < 10)
                CurrentTime = "0" + DateTime.Now.Hour.ToString();
            else
                CurrentTime = DateTime.Now.Hour.ToString();

            if (DateTime.Now.Minute < 10)
                CurrentTime += ":0" + DateTime.Now.Minute.ToString();
            else
                CurrentTime += ":" + DateTime.Now.Minute.ToString();

            if (DateTime.Now.Second < 10)
                CurrentTime += ":0" + DateTime.Now.Second.ToString();
            else
                CurrentTime += ":" + DateTime.Now.Second.ToString();

            return CurrentTime;
        }

        public static string GetCurrentShamsiDate()
        {
            return MiladiToShamsiDate(DateTime.Now, false);
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToLocalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}
