using System;

class Wordle {

  static void Main() {
    var data = CSVReader.Read();    

    //정답으로 사용할 단어 하나를 무작위로 뽑아오기
    Random random = new Random();
    var temp = random.Next(0, 10);
    Console.WriteLine("정답(디버깅용) : " + data[temp]["Name"]);
    string answerWord = data[temp]["Name"];


    //목숨 카운트
    int life = 6;

    //다시 시작할 포인트
    restart:

    //플레이어가 입력하는 단어 읽어오고 목숨 하나 차감하기
    Console.WriteLine("정답으로 예상되는 5글자의 단어를 입력해주세요. " + life + "회 남았습니다.");
    string input = Console.ReadLine();
    life--;

    //정답이면 게임 종료
    if(answerWord == input)
    {
      Console.WriteLine("정답입니다! :)");
      Console.WriteLine("아무 키나 입력해 종료합니다");
      Console.ReadKey();
      return;
    }
    else
    {
      Console.WriteLine("틀렸습니다.");

      //목숨 6개를 모두 소진하면 게임 종료
      if(life < 0)
      {
        Console.WriteLine("제한횟수를 초과했습니다. 패배했습니다... :(");
        Console.WriteLine("아무 키나 입력해 종료합니다");
        Console.ReadKey();
        return;
      }      
      
    
      //5글자가 아닐 경우 되돌림
      if(input == null || input.Length != 5)
      {
        Console.WriteLine("5글자가 아닙니다. 5글자의 단어를 입력해주세요.");
        goto restart;
      }
      //답지 초기화
      string howAnswer = null;

      //받아온 단어 쪼개서 비교하기
      for(int i = 0; i < answerWord.Length; i++)
      {
        if(answerWord[i] == input[i])
        {
          howAnswer += "O";
          continue;
        }
        else
        {
          for(int n = 0; n < answerWord.Length; n++)
          {
            //같은 자리의 단어는 이미 체크했으므로 그 순간 바로 건너뛰기
            if(n == i) continue;

            if(input[i] == answerWord[n])
            {
              howAnswer += "-";
              break;
            }
          }
        }

        //howAnswer에 아무것도 입력되지 않으면 X표
        if(howAnswer == null || howAnswer.Length <= i) howAnswer += "X";
      }
        
      //재시작
      Console.WriteLine(howAnswer);
      goto restart;
      
    }
  }
}
