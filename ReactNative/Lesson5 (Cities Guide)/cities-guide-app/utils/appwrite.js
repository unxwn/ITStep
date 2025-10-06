import { Client, Account, Avatars, Databases } from "react-native-appwrite";

const APPWRITE_ENDPOINT = "https://fra.cloud.appwrite.io/v1";
const APPWRITE_PROJECT_ID = "68cd2fbf001f429c9d7b";

export const client = new Client()
  .setEndpoint(APPWRITE_ENDPOINT)
  .setProject(APPWRITE_PROJECT_ID);

export const account = new Account(client);
export const avatars = new Avatars(client);
export const databases = new Databases(client);
