import { useEffect } from "react";
import { Slot, useRouter } from "expo-router";
import { ThemedView } from "../../components/ThemedView";
import { ThemedText } from "../../components/ThemedText";
import { useUser } from "../../hooks/useUser";

export default function PrivateLayout() {
  const { user, authChecked } = useUser();
  const router = useRouter();

  useEffect(() => {
    if (authChecked && !user) {
      // редіректимо на сторінку логіну (група auth)
      router.replace("/(auth)/login");
    }
  }, [authChecked, user]);

  if (!authChecked) {
    return (
      <ThemedView style={{ flex: 1, justifyContent: "center", alignItems: "center" }}>
        <ThemedText>Loading...</ThemedText>
      </ThemedView>
    );
  }

  // якщо user є — рендеримо дочірні сторінки
  return <Slot />;
}
