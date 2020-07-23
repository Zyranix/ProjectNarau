using SpeechIO;
using System.Threading.Tasks;

public class CalibrationManager: BaseManager {
    private PlayerLogic player;
    private LowerHandle lowerHandle;
    public SpeechOut speechOut;
    public CalibrationManager(PlayerLogic externalPlayer, LowerHandle lowerHandle) {
        player = externalPlayer;
        this.lowerHandle = lowerHandle;
        speechOut = new SpeechOut();
    }
    public override async Task<bool> Execute() {
        await speechOut.Speak("Hold both handles over each other to calibrate them.");
        await Task.Delay(3000);
        player.Calibrate(lowerHandle.GetPosition().x, lowerHandle.GetPosition().z);
        await speechOut.Speak("Nice! Calibration completed, let's start the fun stuff!");
        return true;
    }
}