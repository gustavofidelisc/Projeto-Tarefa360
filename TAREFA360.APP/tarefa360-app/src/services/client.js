import axios from 'axios';

export const HTTPClient = axios.create({
  baseURL: 'https://localhost:7157', // Substitua pela URL base da sua API
  headers:{
    "Acess-Controll-Allow-Origins": "*",
    "Acess-Controll-Allow-Headers": "Authorization",
    "Acess-Controll-Allow-Methods": "GET, POST, OPTIONS, PUT, PATH, DELETE",
    "Content-Type": "application/json;chaset=UTF-8",
  }
});