# Guía de TriMark

Control de tres estados para Windows Forms. Sirve en un formulario y dentro de un `DataGridView`.

Espacio de nombres:

```csharp
using SisUvex.Cuadro_de_herramientas;
```

## Estados

| Marca | Valor | Cómo se ve |
|---|---|---|
| Vacío | `TriMarkValue.Empty` | Cuadro gris, sin marca |
| Paloma | `TriMarkValue.Check` | Paloma blanca sobre verde |
| Equis | `TriMarkValue.Cross` | Equis blanca sobre rojo |

El clic, y también Espacio o Enter con el control enfocado, avanza en este orden:

1. Vacío
2. Paloma
3. Equis
4. Otra vez vacío

Dos clics seguidos cuentan como dos cambios. No se pierde el segundo clic.

## Modos numéricos

Además del enum se puede leer y asignar un entero. El modo define qué número corresponde a cada marca.

| Marca | `TriMarkNumberMode.Enum` | `TriMarkNumberMode.Code` |
|---|---|---|
| Vacío | 0 | 2 |
| Paloma | 1 | 1 |
| Equis | 2 | 0 |

`Enum` es el modo inicial. `Code` usa paloma = 1, equis = 0 y vacío = 2.

La marca que se ve es la que manda. Al cambiar de modo, esa marca se conserva y el entero pasa a la otra escala.

Ejemplo: una equis en modo `Code` vale 0. Al cambiar a `Enum` se sigue viendo la equis y el entero pasa a 2.

## Uso en un formulario

El control se llama `TriMarkBox`. Está en el cuadro de herramientas. También se puede crear en código.

```csharp
TriMarkBox marca = new TriMarkBox();
marca.Location = new Point(20, 20);
marca.Size = new Size(16, 16);
marca.NumberMode = TriMarkNumberMode.Code;
marca.ValueChanged += marca_ValueChanged;
Controls.Add(marca);
```

### Asignar y leer la marca

```csharp
marca.Value = TriMarkValue.Check;   // paloma
marca.Value = TriMarkValue.Cross;   // equis
marca.Value = TriMarkValue.Empty;   // vacío

TriMarkValue actual = marca.Value;
```

### Asignar y leer el entero

`Number` usa el `NumberMode` que tenga el control en ese momento.

```csharp
marca.NumberMode = TriMarkNumberMode.Code;

marca.Number = 1;   // paloma
marca.Number = 0;   // equis
marca.Number = 2;   // vacío

int numero = marca.Number;
```

Las dos formas se pueden mezclar. `Value` siempre es la marca. `Number` siempre es el entero del modo activo.

```csharp
marca.NumberMode = TriMarkNumberMode.Code;
marca.Number = 0;                          // queda en equis

marca.NumberMode = TriMarkNumberMode.Enum;
int numero = marca.Number;                 // 2
TriMarkValue marcaActual = marca.Value;    // Cross
```

### Cuando cambia

`ValueChanged` ocurre si cambia la marca, por clic o por código. No ocurre si se asigna la misma marca que ya tenía.

```csharp
private void marca_ValueChanged(object? sender, EventArgs e)
{
    TriMarkValue actual = marca.Value;
    int numero = marca.Number;
}
```

`NumberModeChanged` ocurre al cambiar el modo. La marca no cambia.

### Solo lectura

```csharp
marca.ReadOnly = true;
```

El clic y el teclado ya no la cambian. Desde código, `Value` y `Number` sí se pueden asignar.

No usar `BackColor = Color.Transparent`. El control pinta su propio fondo.

## Uso en un DataGridView

No se pone un `TriMarkBox` dentro de la celda. Se agrega una columna `TriMarkColumn`. Esa columna pinta la marca, el fondo de la celda y evita las manchas al desplazar la cuadrícula. No hay que copiar ese pintado en cada formulario.

```csharp
dataGridView1.AllowUserToAddRows = false;
dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
{
    Name = "colEmpleado",
    HeaderText = "Empleado",
    ReadOnly = true,
    Width = 150
});

TriMarkColumn colLunes = new TriMarkColumn
{
    Name = "colLunes",
    HeaderText = "Lunes",
    Width = 70,
    NumberMode = TriMarkNumberMode.Code
};
dataGridView1.Columns.Add(colLunes);
```

`EditProgrammatically` hace que el clic cambie la marca y no abra un editor de texto.

La marca dentro de la celda mide 16 por 16.

### Poner el valor

Con el entero del modo de la columna:

```csharp
dataGridView1.Rows[0].Cells["colLunes"].Value = 1;  // paloma
dataGridView1.Rows[0].Cells["colLunes"].Value = 0;  // equis
dataGridView1.Rows[0].Cells["colLunes"].Value = 2;  // vacío
```

Con la marca, en cualquier modo:

```csharp
dataGridView1.Rows[0].Cells["colLunes"].Value = TriMarkValue.Check;
```

Al crear la fila:

```csharp
dataGridView1.Rows.Add("Ana López", 1);
```

Si el dato viene de base de datos, la celda acepta `byte`, `short`, `int`, `long` y un texto numérico (`"0"`, `"1"`, `"2"`). También acepta el texto `"Empty"`, `"Check"` o `"Cross"`.

### Obtener el valor

`cell.Value` es un `object`. Para obtener la marca o el entero se usa `TriMarkPainter`, con el modo de la columna.

```csharp
object? crudo = dataGridView1.Rows[0].Cells["colLunes"].Value;

TriMarkValue marca = TriMarkPainter.FromObject(crudo, colLunes.NumberMode);

int numero = TriMarkPainter.ToNumber(crudo, colLunes.NumberMode);
```

`FromObject` devuelve la marca. `ToNumber` devuelve el entero según el modo. Si el dato no se reconoce, la marca queda en vacío.

### Cuando el usuario hace clic en la celda

```csharp
dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

private void dataGridView1_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex < 0)
        return;

    if (dataGridView1.Columns[e.ColumnIndex] is not TriMarkColumn columna)
        return;

    object? crudo = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
    TriMarkValue marca = TriMarkPainter.FromObject(crudo, columna.NumberMode);
    int numero = TriMarkPainter.ToNumber(crudo, columna.NumberMode);
}
```

Si la celda tenía un entero, el clic guarda otro entero del mismo modo. Si tenía un `TriMarkValue`, el clic guarda otro `TriMarkValue`.

### Cambiar el modo de la columna

```csharp
colLunes.NumberMode = TriMarkNumberMode.Enum;
```

La marca de cada celda se conserva.

- Si la celda guardaba un entero, ese entero se reescribe a la escala nueva.
- Si guardaba un `TriMarkValue`, se queda así. Al leerlo con `ToNumber`, el entero sale en el modo nuevo.

Ejemplo: la celda tiene `0` y la columna está en `Code`, así que se ve una equis. Al pasar la columna a `Enum`, la celda pasa a `2` y se sigue viendo la equis.

### Solo lectura en la cuadrícula

```csharp
colLunes.ReadOnly = true;
```

El clic ya no cambia esa columna. Asignar `cell.Value` desde código sigue funcionando. Si todo el `DataGridView` está en `ReadOnly`, tampoco se puede cambiar con el clic.
