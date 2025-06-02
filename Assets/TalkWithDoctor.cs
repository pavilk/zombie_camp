using UnityEngine;
using System.Collections.Generic;

public class TalkWithDoctor : MonoBehaviour
{
    public Transform FirstTarget;
    public Transform SecondTarget;
    public Transform ThirdTarget;
    public CompassArrowController compass;

    private void OnTriggerEnter2D(Collider2D other){

        var dialogueManager = DialogueManager.Instance;
        if (!PushLever.CanPush && !SwitchToCoridor.CanGoBack)
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "Вася", sentence = "Здравствуйте! А вы не знаете, куда пропали все дети и вожатые" },
                new DialogueLine { speakerName = "Доктор", sentence = "Пионер? Неожиданно. Почему опоздал на зарядку?" },
                new DialogueLine { speakerName = "Доктор", sentence = "Хотя не важно, в лагере вспышка ангины, так что все в изоляторе." },
                new DialogueLine { speakerName = "Вася", sentence = "Ангина? А мне тогда тоже идти в изолятор? " },
                new DialogueLine { speakerName = "Доктор", sentence = "Эм.. Там уже нет мест, так что отправляйся обратно в корпус и побудь в своей комнате." },
                new DialogueLine { speakerName = "Вася", sentence = "Слушаюсь" },
                new DialogueLine { speakerName = "Доктор", sentence = "А и да… Какие-то белки порвали рецепт на активированный уголь, а без него лечение идёт туго." },
                new DialogueLine { speakerName = "Доктор", sentence = "Если найдёшь какие-то полезные листочки, то неси их сюда. Всё, уходи." }
            };

            dialogueManager.StartDialogue(lines);
            compass.SetTarget(FirstTarget);
        }

        else if (!PushLever.CanPush)
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "Вася", sentence = "Я не могу оставаться в комнате, там, там … мальчик хотел меня…" },
                new DialogueLine { speakerName = "Вася", sentence = "точнее мои мозги!!!" },
                new DialogueLine { speakerName = "Доктор", sentence = "Мы пойдём ему аккуратно поможем??, не волнуйся. Так, а это что у тебя в руках?" },
                new DialogueLine { speakerName = "Вася", sentence = "А да, я нашёл бумажку как раз рядом с ним." },
                new DialogueLine { speakerName = "Доктор", sentence = "Как хорошо, не зря.." },
                new DialogueLine { speakerName = "Доктор", sentence = "Ой. Молодец!" },
                new DialogueLine { speakerName = "Доктор", sentence = "Слушай, а ты случаем не ходил никогда в бункер за корпусами?" },
                new DialogueLine { speakerName = "Доктор", sentence = "Нам бы просто немного сахара, который там хранят, а времени совершенно нет, сбегаешь?" },
                new DialogueLine { speakerName = "Вася", sentence = "Хорошо, заняться всё равно нечем. Только пожалуйста помогите Коле.\r\nОн мне дорог как друг, мы с ним так часто играли в днд и баскетбол на улицах Бруклина..." },
                new DialogueLine { speakerName = "?", sentence = "А стоп, игра вроде про советский период." },
                new DialogueLine { speakerName = "Доктор", sentence = "Сахар, товарищ, сахар!" }
            };

            dialogueManager.StartDialogue(lines);
            compass.SetTarget(SecondTarget);
        }
        else
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "Вася", sentence = "П-п-помогите, там это, там пионер такой же, какого вы пошли спать, только..\r\nОн бегал, он побежал за мной, я только бумажку выхватил, а пото…\r\n" },
                new DialogueLine { speakerName = "Доктор", sentence = "Так, давай сначала бумажку. Как вижу, бежишь ты легко и сахар ты не принёс.\r\nНу, что могу сказать. Иди в столовую вниз по улице, поешь, может там сахар найдешь..\r\nПобежал! В темпе, в темпе!\r\n" },
                new DialogueLine { speakerName = "Вася", sentence = "Так, ну в столовой мне точно ничего не грозит, всё-таки повариха у нас боевая!\r\n" }
               
            };

            dialogueManager.StartDialogue(lines);
            compass.SetTarget(ThirdTarget);
        }
        if (GameData.HadLastPaper)
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "Вася", sentence = "Здравствуйте! Держите сахар и последняя часть бумажки, судя по форме!" },
                new DialogueLine { speakerName = "Доктор", sentence = "Отлично! А коллеги говорили, что не сможем два эксперимента одновременно провести!" },
                new DialogueLine { speakerName = "Доктор", sentence = "Грузите андроида в багажник, миссию он прошёл отлично!\r\nПосле такого и в общество таких внедрять не стыдно" },
                new DialogueLine { speakerName = "Андрей", sentence = "О чЕм вы гООвориитее?" },
                new DialogueLine { speakerName = "Доктор", sentence = "Поздравляем Вас, товарищь Дрон. Вы успешный совествкий эксперимент!" },
                new DialogueLine { speakerName = "Доктор", sentence = "Абсолютный иммунитет, идеальная физическая форма и отличная смекалка" },
                new DialogueLine { speakerName = "Доктор", sentence = "АХ-ХА-ХА-ХА-ХА-ХА" }

            };

            dialogueManager.StartDialogue(lines);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.Instance.IsDialoguePlaying)
        {
            DialogueManager.Instance.DisplayNextLine();
        }

    }

}
