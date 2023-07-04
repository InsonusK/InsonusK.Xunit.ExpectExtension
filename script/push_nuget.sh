dotnet nuget push \
  ./nuget-packages/*.nupkg \
  -s nuget \
  --no-symbols true \
  -k $NUGET_TOKEN