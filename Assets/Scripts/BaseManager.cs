using System.Threading.Tasks;
public abstract class BaseManager {
    private BeatmapLoader loader;
    private BeatmapHandler handler;
    public BaseManager() {
    }
    public virtual async Task<bool> Execute() {
        return true;
    }
}