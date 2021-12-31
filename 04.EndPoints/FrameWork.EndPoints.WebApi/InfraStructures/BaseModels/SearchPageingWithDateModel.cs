using System;

namespace FrameWork.EndPoints.WebApi.InfraStructures.BaseModels
{
    public class SearchPageingWithDateModel : SearchPageingModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
