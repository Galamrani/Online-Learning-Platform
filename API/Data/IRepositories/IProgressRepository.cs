namespace OnlineLearning.API;


public interface IProgressRepository
{
    public Task<Progress> AddProgressAsync(Progress progress);
}
