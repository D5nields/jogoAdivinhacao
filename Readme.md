# Jogo da Adivinhação - Árvore Binária de Decisão

## 🎯 Para que Serve?
Este projeto é uma aplicação de console desenvolvida em C# que serve para demonstrar, de forma prática e didática, o funcionamento de uma Estrutura de Dados não-linear: a Árvore Binária de Decisão. 

O programa simula um jogo de adivinhação onde o computador tenta adivinhar o animal em que o usuário está pensando. O grande diferencial científico deste projeto é a sua capacidade de aprendizado dinâmico: caso o computador erre o palpite, ele solicita novas informações ao usuário e expande a árvore lógica na memória em tempo real, tornando-se mais inteligente a cada rodada.

---

## 🧠 Como Funciona?

O jogo utiliza o conceito estrutural de Árvore Binária para segmentar o conhecimento e tomar decisões:

1. **Nós Internos (Perguntas):** Guardam as características ou perguntas que filtram as opções (ex: "É um mamífero?"). Cada pergunta divide o fluxo em duas ramificações.
2. **Arestas (Ligações):** A ligação para a esquerda representa a resposta "Não", enquanto a ligação para a direita representa a resposta "Sim".
3. **Nós Folhas (Palpites):** São as pontas finais da árvore que guardam os nomes dos animais conhecidos.

### O Funil de Categorias (Estado Inicial)
Para tornar a busca mais eficiente, a estrutura inicial da árvore divide os animais por classes biológicas conhecidas:
* **Mamíferos:** Filtrados logo no início e divididos entre terrestres (Cachorro) e aquáticos (Baleia).
* **Répteis:** Acessados caso o animal não seja mamífero (iniciando com Jacaré).
* **Aracnídeos:** Acessados caso as opções anteriores falhem (iniciando com Aranha).
* **Resto:** Uma subárvore genérica (iniciando com Pombo) para qualquer animal que não se encaixe nas categorias acima.

---

## 📈 O Algoritmo de Aprendizado Dinâmico

Quando o usuário pensa em um animal que o computador ainda não conhece, o sistema executa os seguintes passos:
1. **Busca:** O programa percorre a árvore até chegar a um nó folha (um palpite).
2. **Confronto:** O computador faz o palpite final. Se o usuário disser que está errado, o mecanismo de aprendizado é acionado.
3. **Coleta:** O programa pergunta qual era o animal correto e qual característica diferencia esse novo animal do palpite errado.
4. **Reestruturação:** O nó folha antigo é transformado em um novo nó interno de pergunta. O palpite antigo é movido para o lado do "Não" (esquerda) e o novo animal é inserido no lado do "Sim" (direita).

---

## 🚀 Como Executar o Programa pelo Terminal

Toda a lógica e estrutura do jogo foram unificadas em um único arquivo (`Program.cs`) para simplificar a execução. 

Para rodar este projeto na sua máquina local, certifique-se de ter o **SDK do .NET 8.0** (ou superior) instalado. Abra o seu terminal (ou o terminal integrado do VS Code) e siga os passos abaixo:

### 1. Navegar até a pasta do projeto
Certifique-se de que o seu terminal está apontando para a pasta raiz do projeto (onde fica o arquivo principal `JogoAdivinhacao.csproj` e o arquivo `Program.cs`). Caso precise entrar na pasta, use o comando:
```bash
cd JogoAdivinhacao
```

2. Restaurar as dependências (Opcional)
Para garantir que o ambiente do .NET leia corretamente o arquivo único e prepare a compilação, você pode rodar:

```bash
dotnet restore
```

3. Compilar e Rodar o Jogo
Para compilar o código em segundo plano e iniciar o jogo imediatamente direto no seu terminal, execute o comando:

```bash
dotnet run
```

Pronto! O jogo iniciará na tela e você poderá interagir digitando s para Sim e n para Não diretamente pelo teclado do console.
