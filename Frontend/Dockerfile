FROM node:18-alpine
WORKDIR /app
COPY Frontend/package.json .
RUN npm install
COPY Frontend .
EXPOSE 5173
CMD ["npm", "run", "dev"]
