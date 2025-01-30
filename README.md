# Validador de CPF - Azure Function

Este projeto implementa uma Azure Function para validar CPFs (Cadastro de Pessoa Física). A função é desenvolvida em .NET e gerenciada via Azure Functions.

## 🚀 Requisitos
Antes de começar, certifique-se de ter os seguintes itens instalados:

- **Conta no Azure** (se necessário, [crie uma aqui](https://azure.microsoft.com/))
- **Visual Studio Code** ([baixe aqui](https://code.visualstudio.com/))
- **.NET 8** ([baixe aqui](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
- **Node.js** ([baixe aqui](https://nodejs.org/))
- **Postman** ([baixe aqui](https://www.postman.com/downloads/))

## 📌 Instalação

### 1️⃣ Instalar o .NET 8
Baixe e instale o .NET 8 seguindo as instruções do site oficial.

### 2️⃣ Instalar o VS Code
Baixe e instale a versão mais recente do VS Code para o seu sistema operacional.

### 3️⃣ Instalar o Node.js
O Node.js é necessário para instalar as ferramentas do Azure Functions. Baixe a versão LTS e siga as instruções de instalação.

### 4️⃣ Instalar o Postman
O Postman será usado para testar a função localmente.

## ⚙️ Configuração no VS Code

### 1️⃣ Instalar a extensão Azure Functions
1. Abra o VS Code.
2. Vá até a seção de Extensões (ícone de quadrado no menu lateral esquerdo).
3. Pesquise por **"Azure Functions"** e instale a extensão oficial da Microsoft.

### 2️⃣ Criar a Function App no Azure
1. Pressione **Ctrl + Shift + P** para abrir a paleta de comandos.
2. Pesquise por **"Azure: Create Function App"** e selecione a opção.
3. Escolha a assinatura do Azure onde deseja criar a função.
4. Defina um nome para sua Function App (exemplo: `fn-validar-cpf`).

## 🛠️ Comandos Úteis

### 📌 Instalar as Ferramentas do Azure Functions
Caso ainda não tenha as ferramentas instaladas, execute o seguinte comando:
```sh
npm install -g azure-functions-core-tools@4 --unsafe-perm true
```

### 📌 Verificar a Instalação
Para garantir que a instalação foi bem-sucedida, execute:
```sh
func --version
```

### 📌 Inicializar o Projeto
Crie um novo projeto de Azure Functions utilizando .NET:
```sh
func init --worker-runtime dotnet
```

### 📌 Criar uma Nova Função
Crie uma nova função dentro do projeto:
```sh
func new
```
Durante a execução do comando:
- Escolha o tipo de **Trigger**: `HttpTrigger`
- Nomeie a função: `fn-validar-cpf`

### 📌 Executar Localmente
Para rodar a função localmente:
```sh
func start
```
Agora, faça uma requisição **POST** no Postman com o seguinte JSON:
```json
{
  "cpf": "000.000.000-33"
}
```

## 🚀 Publicação no Azure
Após testar localmente, publique sua função no Azure:
```sh
func azure functionapp publish fn-validar-cpf
```
Substitua `fn-validar-cpf` pelo nome da sua Function App no Azure.

## 🌍 Uso da Função no Azure

### 📌 Obter a Chave de Acesso
1. Acesse o **Portal do Azure**.
2. Vá até sua Function App (`fn-validar-cpf`).
3. Navegue até a seção **Funções** e clique na função criada (`fn-validar-cpf`).
4. Copie a **chave de acesso padrão** (geralmente chamada de `default`).

### 📌 Testar no Postman
Faça uma requisição **POST** para a função no Azure:

- **URL:** `https://<seu-nome-app>.azurewebsites.net/api/fn-validar-cpf?code=<sua-chave>`
- **Método:** `POST`
- **Corpo da requisição:**
```json
{
  "cpf": "000.000.000-33"
}
```

## ✅ Conclusão

Seguindo estes passos, você configurou, testou e implantou sua Azure Function para validar CPFs. Agora, pode integrá-la em outras aplicações que suportam requisições HTTP.

💡 Se tiver dúvidas ou problemas, abra uma **issue** ou entre em contato!

