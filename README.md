# Projeto de Integração .NET com Amazon SQS

Este projeto é uma aplicação de estudos que demonstra a integração entre o **.NET** e o **Amazon Simple Queue Service (SQS)**. Ele segue uma arquitetura simples com duas principais pastas:
- **Publisher**: Envia mensagens para a fila SQS.
- **Consumer**: Consome e processa mensagens da fila SQS.

O objetivo principal deste projeto é explorar como o .NET pode interagir com o Amazon SQS para realizar comunicação assíncrona entre serviços.

## Arquitetura

A arquitetura do projeto é dividida em duas partes principais:

### Publisher
O **Publisher** envia mensagens para o Amazon SQS. A lógica é simples:
1. O Publisher cria uma mensagem de exemplo.
2. A mensagem é enviada para a fila do SQS usando a SDK da AWS.

### Consumer
O **Consumer** é responsável por escutar a fila do SQS e processar as mensagens recebidas. Ele realiza as seguintes operações:
1. Conecta-se ao SQS.
2. Aguarda e consome mensagens da fila.
3. Processa as mensagens conforme a lógica definida.

## Tecnologias Utilizadas

- **.NET 8.0**
- **Amazon SQS**
- **Dependency Injection** (para injeção de dependências no .NET)
- **AWS SDK para .NET**
- **Microsoft.Extensions.Configuration** (para configurar as credenciais AWS)

## Pré-requisitos

Antes de rodar o projeto, você precisará:

1. **AWS Account**: Uma conta na AWS com permissões para utilizar o **Amazon SQS**.
2. **AWS Access Key e Secret Key**: Configure suas credenciais da AWS.
3. **.NET SDK 8.0**: Tenha o .NET SDK 8.0 instalado na sua máquina. Caso não tenha, você pode baixar em [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).
4. **Ferramentas**: Uma IDE como **Visual Studio** ou **VS Code**.

## Como Configurar

### 1. Clonar o Repositório

Clone este repositório para sua máquina local:

```bash
git clone https://github.com/luizgomes-dev/amazon-sqs.git
cd amazon-sqs
