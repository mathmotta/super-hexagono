# Super Hexagon - Jogo em 15 minutos!

## Aula

Link para vídeo-aula: 

## Introdução 

Hoje vamos fazer um clone do Super Hexagon! Nessas recriações eu não costumo mostrar cada mínimo detalhe mas sim "dar uma geral" no projeto e como obter o mesmo resultado, assim como fiz no video Flappy Bird em AR. Mas como dessa vez é o Super Hexagon, dá para fazer junto sem tomar muito tempo. 

## Afazeres

Tem algumas coisas que eu fiz antes de gravar que você vai precisar se for seguir esse tutorial:

1. Um triângulo branco
2. Um circulo branco
3. Um Hexágono branco mas apenas a borda e sem um dos lados
4. "Uns sons daora" -- huehue

## Idéia do Jogo

A idéia é que vamos ter um triângulo que roda em torno de um circulo que fica no centro da tela e enquanto isso os hexágonos são criados e diminuem de tamanho. Você poderia criar o hexágono dentro do Unity usando um line renderer ou coisa do tipo para que a linha não ficasse mais fina conforme a gente diminuísse o tamanho também, vai do gosto de cada um.


## Programando Hexágonos... Quem diria?

O primeiro passo é mudar a cor de fundo da câmera para... Qualquer coisa que não seja aquele azul feio padrão do Unity.

Depois, vamos adicionar aqui o hexágono na cena e resetar a posição, adiciona um _PolygonCollider2D_ e um novo script chamado __Hexagono.cs__

```cs
[SerializeField]
private float _velocidade;

void Start()
{
    transform.Rotate(new Vector3(1, 1, Random.Range(0f, 360f)));
}

void Update()
{
    transform.localScale -= Vector3.one * _velocidade * Time.deltaTime;

    if(transform.localScale.x <= .1)
    {
        Destroy(gameObject);
    }
}
```

## Gerando Hexágonos... Obviamente

Agora salvamos o hexagono como prefab e vamos criar um gerador de hexagonos, resetar a posição e adicionar um script __GeradorHexagono.cs__

```cs
[SerializeField]
private float _velocidadeGeracao;
[SerializeField]
private GameObject _hexagono;

void Start()
{
    InvokeRepeating("GeraHexagono", 0, _velocidadeGeracao);
}

public void GeraHexagono()
{
    Instantiate(_hexagono);
}
```

## Criando um jogador... Para desviar dos hexágonos

Agora só falta fazer o jogador! Vamos colocar o circulo na hierarquia, vou diminuir o tamanho para uns 0.2

E agora colocamos o triângulo, que é o jogador, na hierarquia também, diminuir o scale para 0.1 ou algo assim e vamos aumentar o Y em 1 e a idéia é que o jogador rode em volta desse círculo. Também vamos adicionar um _PolygonCollider2D_ nele.

Agora adicionamos um Script __Jogador.cs__

```cs
[SerializeField]
private float _velocidade = 500f;


void Update()
{
    var lado = Input.GetAxisRaw("Horizontal");
    // Vector3.zero centro da tela
    // Vector3.forward o eixo para rodar
    // -lado porque o RotateAround roda num valor oposto
    transform.RotateAround(Vector3.zero, Vector3.forward, -lado * _velocidade * Time.deltaTime);
}
```

Vou desabilitar o GeradorHexagono, e testamos. O jogador está indo para a direção contrária do que o que apertamos, e isso é apenas a forma como o RotateAround funciona. Tudo que temos que fazer é em vez de passar "lado" passamos "-lado". Vou também habilitar o GeradorHexagono.

**Play no Unity**

## Colidindo com... Hexágonos...

Está ficando bonito! Claro que ainda nada acontece quando colidimos então vamos fazer exatamente isso!

```cs
using UnityEngine.SceneManagement;

private void OnTriggerEnter2D(Collider2D collision)
{
    SceneManager.LoadScene(1);
}
```

## Perdendo para Hexágonos

Agora vamos adicionar essa cena no PlayerSettings, esse vai ser nosso Game Over. Mas o que acontece: se dermos Play, ainda não vai funcionar! Isso é porque precisamos adicionar um RigidBody ao nosso jogador. Como nós movemos esse rigidbody unicamente por script, vou mudar o Body type para Kinematic. 

E... Pronto! Agora se a gente perder somos jogados para essa tela.

Nessa tela, não vou fazer nada muito complexo. Vou só pintar ela de preto e adicionar um novo objeto e escript __GerenciadorDeJogo.cs__

Aqui dentro eu detecto se o jogador apertou __ESPAÇO__ e se sim, faço load do jogo!

E agora, se você quiser deixar ainda mais parecido, pode rotacionar a câmera um pouco e agora temos uma coisa bem parecida com o jogo original!

## SUPER HEXÁGONO

E pronto! Isso é tudo que precisamos para ter um Super Hexagon. A partir daqui você pode adicionar pontuação do seu jeito, por tempo ou por número de hexagonos destruídos sei lá. 


Para terminar, vamos colocar uma música... __TUNTS TUNTS TUNTS__

## Despedindo dos Hexágonos

Espero que tenham gostado e até a próxima. FUI!



