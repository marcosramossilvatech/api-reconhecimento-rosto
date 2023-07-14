namespace ReconhecimentoFace.Services
{
    public interface IDetectFaceService
    {
        Task<string> DetectFace(IFormFile file);
    }
}
