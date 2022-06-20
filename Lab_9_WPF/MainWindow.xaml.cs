using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Windows;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab_9_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {



            InitializeComponent();

            List<SnippetReponse> SR = new List<SnippetReponse>();

            int pageNumber = 1;
            int pageSize = 5;
            string snippetsType = "cs";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);

            foreach (SnippetReponse snippet in reponse.Batches)
            {
                SR.Add(new SnippetReponse()
                {
                    Size = snippet.Size,
                    Name = snippet.Name,
                    Type = snippet.Type,
                    CreationTime = snippet.CreationTime,
                    UpdateTime = snippet.UpdateTime
                });
            }
            response.ItemsSource = SR;
        }

        public static string FetchData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                ContentType type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
                Encoding encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static PageReposne FetchSnippets(int pageNumber, int pageSize, string snippetsType)
        {
            string url = $"https://dirask.com/api/snippets?pageNumber={pageNumber}&pageSize={pageSize}&dataOrder=newest&dataGroup=batches&snippetsType={Uri.EscapeUriString(snippetsType)}";
            string data = FetchData(url);

            return JsonSerializer.Deserialize<PageReposne>(data);
        }
    }

    public class PageReposne
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("batches")]
        public List<SnippetReponse> Batches { get; set; }
    }

    public class SnippetReponse
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime? CreationTime { get; set; }

        [JsonPropertyName("updateTime")]
        public DateTime? UpdateTime { get; set; }
    }
}