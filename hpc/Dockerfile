FROM node:16.20.2

COPY client/build /app

WORKDIR /app
# RUN yarn install
# RUN npm run build
RUN npm install -g serve

CMD serve -s .

ENV REACT_APP_POCKETBASE_IP=172.17.0.1 
ENV REACT_APP_POCKETBASE_PORT=8092

EXPOSE 3000