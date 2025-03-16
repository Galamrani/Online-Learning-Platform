namespace OnlineLearning.API;

public class ProgressRepository : IProgressRepository
{
    private readonly LearningPlatformDbContext _dbContext;

    public ProgressRepository(LearningPlatformDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Progress> AddProgressAsync(Progress progress)
    {
        await _dbContext.Progresses.AddAsync(progress);
        return progress;
    }
}
