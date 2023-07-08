dotnet nuget push \
  ./nuget-packages/*.nupkg \
  -s nuget \
  --no-symbols true \
  --disable-buffering true \
  -k $NUGET_TOKEN