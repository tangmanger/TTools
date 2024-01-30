using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace TTools.ViewModels
{
    public class JsonViewModel : BaseTools
    {

        public JsonViewModel()
        {
            var options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.All),
            };
            SourceText = Encoding.UTF8.GetString(JsonSerializer.SerializeToUtf8Bytes(new
            {
                Name = "小明",
                Age = 18,
                Address = "北京市海淀区西三旗街道"
            }, options1));


        }

        #region 属性

        private string sourceText = string.Empty;
        private string targetText = string.Empty;
        private string errorText;

        /// <summary>
        /// 源
        /// </summary>
        public string SourceText
        {
            get => sourceText;

            set
            {
                sourceText = value;
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
        /// <summary>
        /// 错误提示
        /// </summary>
        public string ErrorText
        {
            get => errorText;
            set
            {
                errorText = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region 命令

        /// <summary>
        /// 格式化
        /// </summary>
        public RelayCommand FormatCommand => new RelayCommand(() => FormatText());

        /// <summary>
        /// 压缩
        /// </summary>
        public RelayCommand UnFormatCommand => new RelayCommand(() => FormatText(false));


        /// <summary>
        /// unicode
        /// </summary>
        public RelayCommand UnicodeToSampleChineseCommand => new RelayCommand(() =>
        {
            if (string.IsNullOrWhiteSpace(SourceText)) { return; }
            var options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.All),
            };
            var jsonDocument = JsonDocument.Parse(SourceText);
            SourceText = JsonSerializer.Serialize(jsonDocument, options1);

        });

        /// <summary>
        /// 中文转义
        /// </summary>
        public RelayCommand SampleChineseToUnicodeCommand => new RelayCommand(() =>
        {

            var jsonDocument = JsonDocument.Parse(SourceText);
            SourceText = JsonSerializer.Serialize(jsonDocument);
        });


        /// <summary>
        /// jiaoyan 
        /// </summary>
        public RelayCommand CheckCommand => new RelayCommand(() =>
        {
            if (string.IsNullOrWhiteSpace(SourceText)) { return; }
            try
            {


                var jsonDocument = JsonDocument.Parse(SourceText);
                ErrorText = $"格式正确";
            }
            catch (Exception ex)
            {

                ErrorText = $"格式错误:{ex.Message}";
            }
        });

        #endregion

        void FormatText(bool isFormat = true)
        {
            if (string.IsNullOrWhiteSpace(SourceText)) { return; }
            try
            {


                var jsonDocument = JsonDocument.Parse(SourceText);

                var formatJson = JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions()
                {
                    // 整齐打印
                    WriteIndented = isFormat,
                    //重新编码，解决中文乱码问题
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
                SourceText = formatJson.ToString();
            }
            catch (Exception ex)
            {
                SourceText = ex.Message + "\r\n" + ex.StackTrace;
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
