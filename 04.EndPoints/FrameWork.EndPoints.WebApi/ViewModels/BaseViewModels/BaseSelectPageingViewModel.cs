namespace FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels
{
    public class BaseSelectPageingViewModel
    {
        public bool EnablePaging { get; set; }
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
