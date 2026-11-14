# hello-app

Minimal .NET 10 web API used to exercise the shared CI/CD pipeline in
[JMa9-Dev/platform](https://github.com/JMa9-Dev/platform).

| Endpoint | Description |
|----------|-------------|
| `GET /` | Greeting and environment name |
| `GET /healthz` | Health check |

## Local development

```bash
dotnet run --project src/HelloApp
dotnet test
dotnet format --verify-no-changes
```

## Pipeline

- `pr.yml` – build, `dotnet format` lint and tests on every pull request.
- `deploy.yml` – on push to `main`: CI → publish → deploy **dev**. A prod stage is added
  when the app is ready for real use (see the platform README).

Infrastructure is defined in `infra/dev.bicepparam`, which use the shared template
`infra/appservice/main.bicep` from the platform repository.
