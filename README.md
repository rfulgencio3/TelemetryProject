# TelemetryProject
Este projeto demonstra como podemos implementar Programação Reativa em .NET para lidar com dados de telemetria em um cenário de Fórmula 1. A ideia é que um provedor (TelemetryProvider) emita dados de forma contínua (velocidade, combustível, nome do piloto etc.), e que um monitor (MonitorTelemetryUseCase) assine esse fluxo, filtrando e reagindo aos eventos conforme chegam.

# Visão Geral
Tecnologia: .NET 9
Padrão Reativo: Utiliza Reactive Extensions (Rx.NET) para fornecer e consumir dados de maneira assíncrona e baseada em eventos.
Cenário: Processar dados de telemetria de carros de F1. Por exemplo, velocidade e nível de combustível, alertando quando estiverem abaixo de um certo nível.

# Estrutura de Pastas
## Telemetry.Core.Domain.Entities
Contém as classes de domínio (por ex., TelemetryData), representando dados de telemetria.
## Telemetry.Core.Domain.Interfaces
Interfaces de contrato, como ITelemetryProvider (expondo IObservable<TelemetryData> ou algum fluxo reativo).
## Telemetry.Infrastructure.Providers
Implementações concretas que produzem ou publicam os dados de telemetria (por ex., TelemetryProvider usando Subject<TelemetryData>).
## Telemetry.Application.UseCases
Casos de uso, como MonitorTelemetryUseCase, responsável por assinar (via Subscribe) o fluxo de dados e aplicar filtros ou lógicas de negócio.
Como Funciona

# Provedor de Telemetria (TelemetryProvider)

Implementa um Subject<T> ou IObservable<TTelemetryData> onde são publicados os dados.
Pode chamar algo como PublishTelemetry(new TelemetryData { ... }) para enviar cada novo registro de velocidade, combustível etc.
Monitor de Telemetria (MonitorTelemetryUseCase)

Recebe o ITelemetryProvider via injeção de dependência.
No método StartMonitoring(), chama operadores Rx (ex.: .Where(...), .Select(...)) e assina o stream com .Subscribe(...).
No callback OnNextTelemetry(...), processa cada item (p. ex., exibindo no console, gerando alertas, armazenando no banco etc.).

# Filtro e Alerta
Exemplo de filtro: somente pilotos “Hamilton” ou “Verstappen”.
Exemplo de alerta: imprimir mensagem quando o combustível for menor que 5.0F.
Principais Dependências
System.Reactive
Pacote principal de Rx.NET (Reactive Extensions) para operar com IObservable<T> e IObserver<T>.
.NET 6+
Projeto base em .NET 9. Versão recomendada para suporte de longo prazo.

# Executando o Projeto
## Clone o Repositório
``git clone https://github.com/seu-usuario/f1-telemetry-reactive.git``
``cd f1-telemetry-reactive``
## Restaure e Compile
``dotnet restore``
``dotnet build``
## Execute
Se houver um projeto console principal (ex.: Telemetry.ConsoleApp.csproj), execute:
``dotnet run --project Telemetry.ConsoleApp``
## Verificar Logs
Você deverá ver o console exibindo mensagens sobre cada dado de telemetria publicado (piloto, velocidade, combustível) e alertas quando o combustível estiver abaixo de 5 litros.

# Exemplos de Uso
## Publicando Telemetria
``provider.PublishTelemetry(new TelemetryData 
{
    Driver = "Verstappen",
    Speed = 299.2F,
    Fuel = 4.2F,
    Timestamp = DateTime.UtcNow
});``

## Monitorando Telemetria
``monitor.StartMonitoring();``
// Assina o fluxo, filtra somente "Hamilton" e "Verstappen", e exibe alertas no console quando o Fuel < 5.``

## Personalizando
Filtros:
Pode-se adaptar o .Where(...) para filtrar por circuito ou por limites diferentes de combustível.
Notificações:
Em vez de Console.WriteLine(...), você pode integrar com um serviço de notificação (websocket, SignalR, envio de e-mail etc.).

# Contribuindo
Fork e Pull Requests são bem-vindos!
Sugestões de melhoria, testes unitários e integração com banco de dados também podem ser adicionados.

# Licença
MIT License – fique à vontade para usar e modificar de acordo com suas necessidades.
