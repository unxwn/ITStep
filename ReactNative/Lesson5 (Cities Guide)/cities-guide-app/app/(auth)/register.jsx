import { useState } from "react";
import { StyleSheet, Button, Text } from "react-native";
import { Link, useRouter } from "expo-router";
import { Spacer } from "../../components/Spacer";
import { ThemedText } from "../../components/ThemedText";
import { ThemedView } from "../../components/ThemedView";
import { ThemedTextInput } from "../../components/ThemedTextInput";
import { Controller, useForm } from "react-hook-form";
import { useUser } from "../../hooks/useUser";

export default function Register() {
  const [error, setError] = useState(null);
  const { register: registerUser } = useUser();
  const router = useRouter();

  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({ defaultValues: { email: "", password: "" } });

  const onSubmit = async (data) => {
    try {
      setError(null);
      await registerUser(data.email, data.password);
      // після реєстрації - автоматично перелогінить і можна редіректити
      router.replace("/");
    } catch (err) {
      setError(err.message || "Registration failed");
    }
  };

  return (
    <ThemedView style={styles.container}>
      <ThemedText title={true}>Реєстрація</ThemedText>
      <Spacer height={24} />
      <Controller
        control={control}
        rules={{ required: "Email required" }}
        render={({ field: { onChange, onBlur, value } }) => (
          <ThemedTextInput
            style={styles.textInp}
            placeholder="Email"
            onChangeText={onChange}
            onBlur={onBlur}
            value={value}
            keyboardType="email-address"
            autoCapitalize="none"
          />
        )}
        name="email"
      />
      <Controller
        control={control}
        rules={{ required: "Password required", minLength: { value: 6, message: "Min 6 chars" } }}
        render={({ field: { onChange, onBlur, value } }) => (
          <ThemedTextInput
            style={styles.textInp}
            placeholder="Password"
            onChangeText={onChange}
            onBlur={onBlur}
            secureTextEntry
            value={value}
          />
        )}
        name="password"
      />
      {errors.password && <Text style={styles.validationError}>{errors.password.message}</Text>}
      <Button onPress={handleSubmit(onSubmit)} title="Зареєструватися" />
      {error && <Text style={styles.warning}>{error}</Text>}

      <ThemedView style={styles.linkGroup}>
        <Link href="/" style={styles.link}>
          <ThemedText>На головну</ThemedText>
        </Link>
        <Link href="/(auth)/login" style={styles.link}>
          <ThemedText>Вже є акаунт? Увійти</ThemedText>
        </Link>
      </ThemedView>
    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  link: { marginTop: 20, fontSize: 20, color: "blue" },
  linkGroup: { flexDirection: "row", gap: 20, justifyContent: "center" },
  textInp: { marginBottom: 16, width: "80%" },
  validationError: { textAlign: "center", color: "red", marginTop: 8 },
  warning: {
    marginTop: 12,
    backgroundColor: "#ffdddd",
    color: "#900",
    padding: 8,
    borderRadius: 6,
  },
});
