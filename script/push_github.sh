dotnet nuget push \
  ./nuget-packages/*.nupkg \
  -s github \
  --no-symbols true \
  -k $NUGET_GITHUB