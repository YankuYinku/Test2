$prevPwd = $PWD; Set-Location -ErrorAction Stop -LiteralPath $PSScriptRoot

kubectl kustomize ./overlays/prod
kubectl apply -k ./overlays/prod

kubectl rollout restart deployment/portal-root

$prevPwd | Set-Location