namespace FrameWork.EndPoints.WebApi.InfraStructures.BaseModels
{
    public class SearchPageingModel
    {
        private int page = 1;
        public int PageSize { get; set; }
        public int Page
        {
            get => page;
            set
            {
                if (value <= 0)
                    page = 1;
                else
                    page = (value + 1);
            }
        }
    }
}
