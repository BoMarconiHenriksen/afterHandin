# Production
# The low node alpine version is because of ubuntu
FROM node:8.12-alpine as builder

WORKDIR '/app'

COPY ./package*.json /app/

RUN npm install -g @quasar/cli
RUN npm install --save-dev quasar-cli@latest

COPY . /app/
RUN quasar build

FROM nginx
EXPOSE 8080
COPY ./nginx/default.conf /etc/nginx/conf.d/default.conf
COPY --from=builder /app/dist/spa /usr/share/nginx/html
