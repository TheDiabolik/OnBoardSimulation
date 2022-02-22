using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public class MyTypeConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);

            List<Track> members = value as List<Track>;
            if (members == null)
                return "-";

            return string.Join(", ", members.Select(m => m.Track_ID.ToString()));
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            List<PropertyDescriptor> list = new List<PropertyDescriptor>();
            List<Track> members = value as List<Track>;
            if (members != null)
            {
                foreach (Track member in members)
                {
                    if (member.Track_ID != 0)
                    {
                        list.Add(new MemberDescriptor(member, list.Count));
                    }
                }
            }
            return new PropertyDescriptorCollection(list.ToArray());
        }

        private class MemberDescriptor : SimplePropertyDescriptor
        {
            public MemberDescriptor(Track member, int index)
                : base(member.GetType(), index.ToString(), typeof(string))
            {
                Member = member;
            }

            public Track Member { get; private set; }

            public override object GetValue(object component)
            {
                return Member.Track_ID.ToString();
            }

            public override void SetValue(object component, object value)
            {
                //Member.Track_ID = (string)value;
            }
        }
    }
}
