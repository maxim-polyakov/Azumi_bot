using Microsoft.Data.Analysis;

namespace DB_package
{
    public class SentimentData
    {
        public PrimitiveDataFrameColumn<int> id { get; set; }

        public StringDataFrameColumn text { get; set; }

        public StringDataFrameColumn agenda { get; set; }

        public BooleanDataFrameColumn agendaid { get; set; }

        public BooleanDataFrameColumn hi { get; set; }

        public BooleanDataFrameColumn business { get; set; }

        public BooleanDataFrameColumn weather { get; set; }

        public BooleanDataFrameColumn thanks { get; set; }

        public BooleanDataFrameColumn emotionid { get; set; }

        public BooleanDataFrameColumn trash { get; set; }
    }
}
