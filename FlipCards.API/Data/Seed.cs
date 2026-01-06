using FlipCards.API.Models;

namespace FlipCards.API.Data
{
    public class Seed
    {
        // Seed data för FlipCards baserat på Azure-quiz
        public static void SeedFlipCards(AppDbContext db)
        {
            if(db.FlipCards.Count()> 0)
            { 
                return; 
            }
            // Quiz 1: Molntjänster
            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilka är de tre huvudsakliga molntjänstmodellerna?",
                Back = "IaaS, PaaS, SaaS"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är Azure?",
                Back = "En leverantör av datakraft, lagring och mjukvara via datahallar världen över"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "I IaaS, vem ansvarar för mjukvaruuppdateringar?",
                Back = "Kunden ansvarar för mjukvara, uppdateringar, installation och säkerhet"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Ge exempel på PaaS-tjänster i Azure",
                Back = "App Service och Azure SQL Database"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad kännetecknar SaaS?",
                Back = "Prenumerationsmodell där en instans servar alla kunder via internet"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är en Hybrid-lösning?",
                Back = "En kombination av OnPrem och molntjänster"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilka är de tre huvudkategorierna av Azure-tjänster?",
                Back = "Compute, Storage, Network"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är App Service?",
                Back = "En PaaS-tjänst för att hosta webbappar och API:er"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Var lagrar du miljövariabler i App Service?",
                Back = "I Application Settings/Environment Variables"
            });

            // Quiz 2: Azure Storage
            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilka fem typer av lagringstjänster finns i Azure Storage?",
                Back = "Blob, Files, Queues, Tables, Container Storage"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad betyder LRS (Locally Redundant Storage)?",
                Back = "Data replikeras 3 gånger inom ett enda datacenter"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilken redundansnivå ger högst skydd (16 nior)?",
                Back = "GZRS - replikerar både inom zoner och till sekundär region"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är skillnaden mellan GRS och RA-GRS?",
                Back = "RA-GRS ger läsåtkomst till sekundär region även vid normal drift"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad används Azure Blob Storage till?",
                Back = "För enorma mängder ostrukturerad data som bilder, video, audio och säkerhetskopior"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Hur ser strukturen ut i Azure Blob Storage?",
                Back = "Storage Account → Container → Blob"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilka protokoll används för Azure Files?",
                Back = "SMB, NFS och Azure Files REST API"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är skillnaden mellan DTU och vCore?",
                Back = "DTU är en kombinerad resursmodell (paketpris), vCore ger separat kontroll över CPU och lagring"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Hur ofta tar Azure SQL Database automatiska säkerhetskopior?",
                Back = "Fullständiga kopior varje vecka, skillnader varje dag, transaktioner varje 10:e minut"
            });

            // Quiz 3: Azure Functions
            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är Azure Functions?",
                Back = "Serverless-funktioner (kod) som körs vid en trigger"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är en Function App?",
                Back = "En container för flera Azure Functions som delar konfiguration"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är en Binding i Azure Functions?",
                Back = "Ett sätt att integrera med andra tjänster utan att skriva connection-kod"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilken prisplan har coldstart och max 10 min timeout?",
                Back = "Consumption plan"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är skillnaden mellan Function och Anonymous authorization?",
                Back = "Anonymous kräver ingen autentisering, Function kräver function keys"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "I vilken ordning läser .NET Configuration Manager källorna?",
                Back = "appsettings.json → appsettings.{Environment}.json → User Secrets → Environment Variables"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är Azure Key Vault?",
                Back = "Ett säkert valv för att lagra secrets, keys och certificates"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilka tre typer av data kan lagras i Key Vault?",
                Back = "Secrets, Keys, Certificates"
            });

            // Quiz 4: Service Bus
            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är Azure Service Bus?",
                Back = "En fullständigt hanterad meddelandetjänst (message broker) för att koppla ihop applikationer"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är fördelen med löst kopplade system?",
                Back = "Tjänster kan arbeta oberoende; om en tjänst är nere väntar meddelanden i kö"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Hur hjälper Service Bus med lastbalansering?",
                Back = "Meddelanden fördelas automatiskt mellan flera workers för parallell bearbetning"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är ett Service Bus Namespace?",
                Back = "En container för alla Service Bus-resurser (queues, topics) med egen connection string"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är skillnaden mellan Queue och Topic?",
                Back = "Queue är för ett-till-ett meddelanden, Topic är för pub/sub (ett-till-många)"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilket NuGet-paket för Service Bus i .NET?",
                Back = "Azure.Messaging.ServiceBus"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilken klass skickar meddelanden i Service Bus?",
                Back = "ServiceBusSender"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är Azure Monitor/Application Insights?",
                Back = "En central övervakningstjänst som samlar, analyserar och visualiserar telemetri"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilka typer av data samlar Application Insights in?",
                Back = "Requests, exceptions, traces, dependencies, performance metrics"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Hur länge lagras data i Application Insights?",
                Back = "90 dagar som standard (upp till 730 dagar utan extra kostnad)"
            });

            // Quiz 5: Deploy och Containers
            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är en Pipeline i deployment-sammanhang?",
                Back = "Scriptkod (YAML) som utför flera steg från kod till applikation"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad står CI för i CI/CD?",
                Back = "Continuous Integration"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad kan Static Web Apps hosta?",
                Back = "HTML, CSS, Javascript och bilder"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är Deployment Slots?",
                Back = "Kopior av din app med olika syften"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är en Container?",
                Back = "En paketerad enhet mjukvara med alla dess beroenden"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilket problem löser containers?",
                Back = "Det fungerar på min maskin-problemet"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är skillnaden mellan Docker Image och Container?",
                Back = "Image är en mall/blueprint, Container är en körande instans"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är en Dockerfile?",
                Back = "Bygginstruktioner för hur en image ska skapas"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vilken Azure-tjänst för enstaka containers utan klusterhantering?",
                Back = "Azure Container Instances (ACI)"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Vad är Azure Container Registry (ACR)?",
                Back = "Ett register för att bygga, lagra och versionshantera container images"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Varför använda minimala bas-images som Alpine?",
                Back = "Mindre images = snabbare deployment och mindre attack surface"
            });

            db.FlipCards.Add(new FlipCard
            {
                Front = "Varför INTE lagra data direkt i en container?",
                Back = "Containers kan dö och återuppstå - data försvinner"
            });

            db.SaveChanges();
        }
    }
}
