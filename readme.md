#  FBBN Imóveis - WIP

**FBBN Imóveis** é uma plataforma web para exibição e gerenciamento de imóveis desenvolvida com tecnologias modernas e escaláveis. A aplicação serve como vitrine digital para uma imobiliária, com foco em performance, facilidade de manutenção e integração com serviços em nuvem.

##  Visão Geral

- 🌐 **Frontend:** [Nuxt 3](https://nuxt.com) (Vue.js)
- 🧠 **Backend:** ASP.NET Core Web API
- 💾 **Banco de dados:** Amazon DynamoDB (NoSQL)
- 🗂️ **Armazenamento de imagens:** Amazon S3
- 🐳 **Infraestrutura:** Docker (deploy na Oracle Cloud Free Tier)


## Tecnologias & Recursos

| Camada       | Tecnologia                          | Finalidade                                 |
|--------------|--------------------------------------|--------------------------------------------|
| Frontend     | Nuxt 3 + Vue                        | SSR moderno e performático               |
| Backend      | ASP.NET Core                        | API REST segura e robusta                  |
| Banco        | AWS DynamoDB                        | Armazenamento de dados dos imóveis         |
| Imagens      | AWS S3                              | Upload e exibição de imagens               |
| Deploy       | Docker + Oracle Cloud               | Hospedagem escalável            |
| Docs API     | Swagger/OpenAPI                     | Documentação interativa da API             |



## Funcionalidades

- 📋 Listagem de imóveis com dados do DynamoDB
- 📸 Exibição de imagens armazenadas na AWS S3
- 🔐 Painel administrativo com acesso seguro para criação/edição
- 🚀 API RESTful pronta para consumo por qualquer frontend
- ⚙️ Docker-ready para deploy em qualquer nuvem


##  Integração com AWS

- **DynamoDB:** utilizado como banco NoSQL para armazenar dados estruturados dos imóveis.
- **S3:** armazenamento e acesso rápido às imagens dos imóveis (via URL pública).
- As credenciais de acesso à AWS são configuradas com segurança por variáveis de ambiente ou serviços gerenciados.


## Escalabilidade & Deploy

O projeto foi planejado para ser hospedado de forma econômica e escalável:

- Hospedagem planejada na **Oracle Cloud (Free Tier)**
- Utilização de **Docker** para garantir portabilidade
- API e frontend isolados em containers distintos


## Desenvolvedores

| Nome         | Papel               |
|--------------|---------------------|
| Pedro F.     | Back-end & Infra   |
| Luan F.      | Front-end & Design   |
