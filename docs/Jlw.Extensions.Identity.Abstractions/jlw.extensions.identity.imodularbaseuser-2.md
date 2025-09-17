[`< Back`](./)

---

# IModularBaseUser&lt;TKey, TClaim&gt;

Namespace: Jlw.Extensions.Identity

```csharp
public interface IModularBaseUser<TKey, TClaim>
```

#### Type Parameters

`TKey`<br>

`TClaim`<br>

## Properties

### **Id**

```csharp
public abstract TKey Id { get; set; }
```

#### Property Value

TKey<br>

### **UserName**

```csharp
public abstract string UserName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **NormalizedUserName**

```csharp
public abstract string NormalizedUserName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Email**

```csharp
public abstract string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **NormalizedEmail**

```csharp
public abstract string NormalizedEmail { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **EmailConfirmed**

```csharp
public abstract bool EmailConfirmed { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **PasswordHash**

```csharp
public abstract string PasswordHash { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PhoneNumber**

```csharp
public abstract string PhoneNumber { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PhoneNumberConfirmed**

```csharp
public abstract bool PhoneNumberConfirmed { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **TwoFactorEnabled**

```csharp
public abstract bool TwoFactorEnabled { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **AccessFailedCount**

```csharp
public abstract int AccessFailedCount { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **LockoutEnabled**

```csharp
public abstract bool LockoutEnabled { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **LockoutEnd**

```csharp
public abstract Nullable<DateTimeOffset> LockoutEnd { get; set; }
```

#### Property Value

[Nullable&lt;DateTimeOffset&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **SecurityStamp**

```csharp
public abstract string SecurityStamp { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ConcurrencyStamp**

```csharp
public abstract string ConcurrencyStamp { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Claims**

```csharp
public abstract ICollection<TClaim> Claims { get; }
```

#### Property Value

ICollection&lt;TClaim&gt;<br>

## Methods

### **CopyFrom(IModularBaseUser&lt;TKey, TClaim&gt;)**

```csharp
IModularBaseUser<TKey, TClaim> CopyFrom(IModularBaseUser<TKey, TClaim> o)
```

#### Parameters

`o` [IModularBaseUser&lt;TKey, TClaim&gt;](./jlw.extensions.identity.imodularbaseuser-2.md)<br>

#### Returns

[IModularBaseUser&lt;TKey, TClaim&gt;](./jlw.extensions.identity.imodularbaseuser-2.md)<br>

### **CopyFrom(Object)**

```csharp
IModularBaseUser<TKey, TClaim> CopyFrom(object o)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[IModularBaseUser&lt;TKey, TClaim&gt;](./jlw.extensions.identity.imodularbaseuser-2.md)<br>

---

[`< Back`](./)
