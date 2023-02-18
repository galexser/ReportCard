using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReportCard.Helper
{
    public class CalendarLoader
    {
        public static  calendar GetCalendar(string path)
        {
            calendar ret = new calendar();
            XmlSerializer formatter = new XmlSerializer(typeof(calendar));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ret = formatter.Deserialize(fs) as calendar;
            }
            return ret;
        }

        [Serializable()]
        
        [XmlType(AnonymousType = true)]
        [XmlRoot(Namespace = "", IsNullable = false)]
        public class calendar
        {

            private List<calendarHoliday> holidaysField;

            private List<calendarDay> daysField;

            private ushort yearField;

            private string langField;

            private string dateField;

            private string countryField;

            /// <remarks/>
            [XmlArrayItem("holiday", IsNullable = false)]
            public List<calendarHoliday>holidays
            {
                get
                {
                    return this.holidaysField;
                }
                set
                {
                    this.holidaysField = value;
                }
            }

            /// <remarks/>
            [XmlArrayItem("day", IsNullable = false)]
            public List<calendarDay> days
            {
                get
                {
                    return this.daysField;
                }
                set
                {
                    this.daysField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public ushort year
            {
                get
                {
                    return this.yearField;
                }
                set
                {
                    this.yearField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string lang
            {
                get
                {
                    return this.langField;
                }
                set
                {
                    this.langField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string date
            {
                get
                {
                    return this.dateField;
                }
                set
                {
                    this.dateField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string country
            {
                get
                {
                    return this.countryField;
                }
                set
                {
                    this.countryField = value;
                }
            }
        }

        [Serializable()]
        
        [XmlType(AnonymousType = true)]
        public class calendarHoliday
        {

            private byte idField;

            private string titleField;

            /// <remarks/>
            [XmlAttribute()]
            public byte id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public string title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }
        }

        [Serializable()]
        [XmlType(AnonymousType = true)]
        public class calendarDay
        {

            private decimal dField;

            private byte tField;

            private byte hField;

            private bool hFieldSpecified;

            private decimal fField;

            private bool fFieldSpecified;

            /// <remarks/>
            [XmlAttribute()]
            public decimal d
            {
                get
                {
                    return this.dField;
                }
                set
                {
                    this.dField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public byte t
            {
                get
                {
                    return this.tField;
                }
                set
                {
                    this.tField = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public byte h
            {
                get
                {
                    return this.hField;
                }
                set
                {
                    this.hField = value;
                }
            }

            /// <remarks/>
            [XmlIgnore()]
            public bool hSpecified
            {
                get
                {
                    return this.hFieldSpecified;
                }
                set
                {
                    this.hFieldSpecified = value;
                }
            }

            /// <remarks/>
            [XmlAttribute()]
            public decimal f
            {
                get
                {
                    return this.fField;
                }
                set
                {
                    this.fField = value;
                }
            }

            /// <remarks/>
            [XmlIgnore()]
            public bool fSpecified
            {
                get
                {
                    return this.fFieldSpecified;
                }
                set
                {
                    this.fFieldSpecified = value;
                }
            }
        }


    }
}
