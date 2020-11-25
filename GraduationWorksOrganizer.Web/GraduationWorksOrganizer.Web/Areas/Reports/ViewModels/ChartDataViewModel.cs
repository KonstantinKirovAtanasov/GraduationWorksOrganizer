using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace GraduationWorksOrganizer.Web.Areas.Reports.ViewModels
{
    public class ChartMarksDataViewModel
    {
        [JsonIgnore]
        public int ChartId { get; internal set; }

        [JsonPropertyName("chart")]
        public ChartType ChartType => new ChartType() { Type = "column" };

        [JsonPropertyName("title")]
        public Title Title => new Title() { Text = SubTitle };

        [JsonPropertyName("xAxis")]
        public XAxisConfiguration XAxisConfiguration => new XAxisConfiguration() { Categories = Categories.Select(p => p.CategoryName), Crosshair = true };

        [JsonPropertyName("yAxis")]
        public Configuration conf { get; set; } = new Configuration() { Title = new Title() { Text = "Оценки (бр.)" }, Min = 0 };

        [JsonPropertyName("series")]
        public IEnumerable<Series> Series { get; set; }


        [JsonIgnore]
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        [JsonIgnore]
        public string SubTitle { get; set; }
    }

    public class CategoryViewModel
    {
        [JsonPropertyName("name")]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public int CategoryId { get; set; }
    }

    public class Series
    {
        [JsonPropertyName("name")]
        public string SeriesName { get; set; }

        [JsonIgnore]
        public decimal DownBorder { get; set; }

        [JsonIgnore]
        public decimal UpBorder { get; set; }

        [JsonPropertyName("data")]
        public IList<int> SeriesValues { get; set; }
    }

    public class Configuration
    {
        [JsonPropertyName("min")]
        public int Min { get; set; }

        [JsonPropertyName("title")]
        public Title Title { get; set; }

    }

    public class XAxisConfiguration
    {
        [JsonPropertyName("categories")]
        public IEnumerable<string> Categories { get; set; }

        [JsonPropertyName("crosshair")]
        public bool Crosshair { get; set; }
    }

    public class ChartType
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Title
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

}
