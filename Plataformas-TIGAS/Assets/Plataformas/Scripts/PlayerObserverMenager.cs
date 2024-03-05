using System;

//Canal
public class PlayerObserverMenager
{
    //permite que qualquer usuario se inscreva no canal (analogia do youtube)
    public static event Action<int> OnPlayerChanged;

    //Permite que o criador de conteudo mande um video novo
    public static void PlayerChanged(int valuePlayer)
    {
        // Permite que os inscritos recebam a notificação
        OnPlayerChanged?.Invoke(valuePlayer);
    }
}
