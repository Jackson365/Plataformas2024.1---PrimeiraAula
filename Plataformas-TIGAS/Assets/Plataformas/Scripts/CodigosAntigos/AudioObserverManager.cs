using System;

//criar o youtube
public class AudioObserverManager
{
    //permite que qualquer usuario se inscreva no canal (analogia do youtube)
    public static event Action<float> OnVolumeChanged;

    //Permite que o criador de conteudo mande um video novo
    public static void PlayerChanged(float volume)
    {
        // Permite que os inscritos recebam a notificação
        OnVolumeChanged?.Invoke(volume);
    }
}
