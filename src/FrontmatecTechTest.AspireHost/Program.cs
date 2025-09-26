var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FrontmatecTechTest_Web>("web");

builder.Build().Run();
