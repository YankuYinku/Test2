kubectl create secret generic appsetting-sserviceprincipal `
  --from-literal=AZURE_CLIENT_ID=<Add Client Id here> `
  --from-literal=AZURE_CLIENT_SECRET=<Add Client Secret here>