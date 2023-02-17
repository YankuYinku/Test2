#!/usr/bin/env sh

# Make sure line endings are "LF" (Linux) and not "CRLF" (windows). Otherwise you get the error
# > env: can't execute 'sh
# > ': No such file or directory

set -eu

# Find environment env var
environment=$SINGLESPA_ENVIRONMENT
echo "Environment $environment"

cp /usr/share/nginx/html/importmap.$environment.json /usr/share/nginx/html/importmap.json

exec "$@"
