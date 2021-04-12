using System;
using System.Collections.Generic;
using System.Text;

namespace Link3D_API
{
    public class XmlReader
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.gesmes.org/xml/2002-08-01", IsNullable = false)]
        public partial class Envelope
        {

            public string subjectField;

            public EnvelopeSender senderField;

            public Cube cubeField;

            /// <remarks/>
            public string subject
            {
                get
                {
                    return this.subjectField;
                }
                set
                {
                    this.subjectField = value;
                }
            }

            /// <remarks/>
            public EnvelopeSender Sender
            {
                get
                {
                    return this.senderField;
                }
                set
                {
                    this.senderField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
            public Cube Cube
            {
                get
                {
                    return this.cubeField;
                }
                set
                {
                    this.cubeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.gesmes.org/xml/2002-08-01")]
        public partial class EnvelopeSender
        {

            public string nameField;

            /// <remarks/>
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref", IsNullable = false)]
        public partial class Cube
        {

            public CubeCube cube1Field;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Cube")]
            public CubeCube Cube1
            {
                get
                {
                    return this.cube1Field;
                }
                set
                {
                    this.cube1Field = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public partial class CubeCube
        {

            public Currency[] cubeField;

            public System.DateTime timeField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Cube")]
            public Currency[] Cube
            {
                get
                {
                    return this.cubeField;
                }
                set
                {
                    this.cubeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
            public System.DateTime time
            {
                get
                {
                    return this.timeField;
                }
                set
                {
                    this.timeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
        public partial class Currency
        {

            public string currencyField;

            public decimal rateField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string currency
            {
                get
                {
                    return this.currencyField;
                }
                set
                {
                    this.currencyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal rate
            {
                get
                {
                    return this.rateField;
                }
                set
                {
                    this.rateField = value;
                }
            }
        }


    }
}
