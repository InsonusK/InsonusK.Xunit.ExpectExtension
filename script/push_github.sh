dotnet nuget push \
  ./nuget-packages/*.nupkg \
  -s github \
  -k $NUGET_GITHUB