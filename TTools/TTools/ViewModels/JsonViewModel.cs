using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace TTools.ViewModels
{
    public class JsonViewModel : BaseTools
    {

        #region 属性

        private string sourceText = string.Empty;
        private string targetText = string.Empty;

        /// <summary>
        /// 源
        /// </summary>
        public string SourceText
        {
            get => sourceText;

            set
            {
                sourceText = value;
                FormatText();
                OnPropertyChanged();
            }
        }
        public string TargetText
        {
            get => targetText;
            set
            {
                targetText = value;
                OnPropertyChanged();
            }
        }

        #endregion


        void FormatText()
        {
            if (string.IsNullOrWhiteSpace(SourceText)) { return; }
            try
            {


                var jsonDocument = JsonDocument.Parse(SourceText);

                var formatJson = JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions()
                {
                    // 整齐打印
                    WriteIndented = true,
                    //重新编码，解决中文乱码问题
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
                TargetText = formatJson.ToString();
            }
            catch (Exception ex)
            {
                TargetText = ex.Message + "\r\n" + ex.StackTrace;
            }
            //JsonSerializer serializer = JsonSerializer.Create(); 
            //TextReader tr = new StringReader(str);
            //            JsonTextReader jtr = new JsonTextReader(tr);
            //            object obj = serializer.Deserialize(jtr);
            //            if (obj != null)
            //            {
            //                StringWriter textWriter = new StringWriter();
            //                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
            //                {
            //                    Formatting = Formatting.Indented,

            //};
            //                serializer.Serialize(jsonWriter, obj);
            //                return textWriter.ToString();
            //            }
            //            else
            //            {
            //                return str;
            //            }
        }
    }
}
