# Cambios Realizados en el Módulo PricesGtin

## Resumen General
Se ha realizado una refactorización significativa del módulo `PricesGtin` para soportar la asignación de precios tanto a nivel de GTIN como a nivel de GTIN + Tamaño. El sistema es completamente escalable y puede ser fácilmente extendido para soportar nuevas combinaciones en el futuro.

## Cambios en la Estructura de Datos

### Nueva Tabla
- **Pack_PricePerSize**: Nueva tabla que almacena la relación entre precio, GTIN y tamaño.
  - Estructura:
    ```sql
    CREATE TABLE Pack_PricePerSize
    (
        id_price    CHAR(3),
        id_gtin     CHAR(5),
        id_size     CHAR(2),
        userCreate  VARCHAR(12),
        d_create    DATE,
        userUpdate  VARCHAR(12),
        d_update    DATE
    )
    ```
  - Notas: El soft delete se implementa poniendo `id_price = NULL`
  - En el catálogo se muestran solo los registros donde `id_price IS NOT NULL`

## Cambios en la Clase ClsPricesGtin.cs

### Nuevas Propiedades y Métodos

1. **Enum PricingType**
   - `Gtin`: Para manejar precios a nivel GTIN
   - `GtinAndSize`: Para manejar precios a nivel GTIN + Tamaño
   - Propiedad: `CurrentPricingType` (por defecto: Gtin)

2. **DataTable dtCatalogSize**
   - DataTable adicional para almacenar datos de precios por tamaño

3. **Métodos Nuevos**
   - `BtnSearchFilterSize()`: Aplica filtros al dgvCatalogSize
   - `LoadDataGridViewsAdd()`: Carga ambos DataGridViews (Left y Right)
   - `LoadDgvPricesLeft()`: Carga el DataGridView izquierdo con GTINs sin asignar
   - `LoadDgvPricesRight()`: Carga el DataGridView derecho con GTINs asignados
   - `GetAssignedGtinsDataTable()`: Obtiene los GTINs ya asignados a un precio
   - `MoveRowLeftToRight()`: Mueve una fila de Left a Right
   - `MoveRowRightToLeft()`: Mueve una fila de Right a Left
   - `ApplyFilterAdd()`: Aplica filtros al formulario Add
   - `SaveGtinPrices()`: Guarda cambios para precios por GTIN
   - `SaveGtinAndSizePrices()`: Guarda cambios para precios por GTIN + Tamaño
   - `GetGtinsFromDataGridView()`: Extrae una lista de GTINs desde un DataGridView
   - `GetGtinsAndSizesFromDataGridView()`: Extrae una lista de pares (GTIN, Size) desde un DataGridView
   - `GetCurrentUser()`: Obtiene el usuario actual del sistema
   - `GetQueryDgvSizeCatalog()`: Obtiene la consulta SQL para el catálogo de tamaños
   - `GetRowFilterSize()`: Genera el filtro para el dgvCatalogSize

4. **Métodos Refactorizados**
   - `SavePricesGtin()`: Ahora es un dispatcher que llama a SaveGtinPrices() o SaveGtinAndSizePrices() según CurrentPricingType
   - `BeginFormCat()`: Ahora carga también el dtCatalogSize y la carga al formulario
   - `BeginFormAdd()`: Refactorizado para cargar ambos DataGridViews

## Cambios en el Formulario FrmPricesGtinAdd.Designer.cs

### Cambios de Diseño
1. **Título del Formulario**: Actualizado a "Precios por Gtin y Tamaño"
2. **Botones Agregados**
   - `button1` (Agregar): Mueve filas de dgvPricesLeft a dgvPricesRight
   - `button2` (Quitar): Mueve filas de dgvPricesRight a dgvPricesLeft

### Nuevos DataGridViews
- `dgvPricesLeft`: Muestra GTINs sin asignar o no seleccionados
- `dgvPricesRight`: Muestra GTINs asignados al precio

### Filtros Disponibles
Se mantienen todos los filtros del formulario de catálogo:
- Cultivo (cboCrop)
- Variedad (cboVariety)
- Contenedor (cboContainer)
- Presentación (cboPresentation)
- Distribuidor (cboDistributor)
- Libras (txbLbs)
- Botón de búsqueda (btnSearch)

**Importante**: Los filtros solo afectan al `dgvPricesLeft`, no al `dgvPricesRight`.

## Cambios en el Formulario FrmPricesGtinCat.Designer.cs

### Nuevos Controles
- `dgvCatalogSize`: DataGridView que muestra precios por GTIN y tamaño
- `cboSize`: ComboBox para filtrar por tamaño
- `btnSearchSize`: Botón para aplicar filtros en el dgvCatalogSize

### Estructura de Split Containers
Se mantiene la estructura de SplitContainers pero ahora Panel2 contiene otro SplitContainer vertical (splitContainer2) con:
- Panel1: dgvCatalogGtin
- Panel2: dgvCatalogSize (nuevo)

## Cambios en el Formulario FrmPricesGtinAdd.cs

### Event Handlers Nuevos
- `button1_Click()`: Llama a `cls.MoveRowLeftToRight()`
- `button2_Click()`: Llama a `cls.MoveRowRightToLeft()`
- `btnSearch_Click()`: Llama a `cls.ApplyFilterAdd()`

### Inicialización de Controles
- `InitializeControls()`: Carga todos los ComboBox con datos activos

## Cambios en el Formulario FrmPricesGtinCat.cs

### Event Handler Nuevo
- `btnSearchSize_Click()`: Llama a `cls.BtnSearchFilterSize()`

## Lógica de Actualización en Base de Datos

### Para Pack_GTIN (SaveGtinPrices)
```sql
UPDATE Pack_GTIN SET id_price = '{idPrice}' 
WHERE id_GTIN IN ('{listaGTINs}');

UPDATE Pack_GTIN SET id_price = NULL 
WHERE id_price = '{idPrice}' 
AND id_GTIN NOT IN ('{listaGTINs}');
```

### Para Pack_PricePerSize (SaveGtinAndSizePrices)
Para cada combinación (id_gtin, id_size):
```sql
IF EXISTS (SELECT 1 FROM Pack_PricePerSize WHERE id_GTIN = '{idGtin}' AND id_size = '{idSize}')
    UPDATE Pack_PricePerSize SET id_price = '{idPrice}', userUpdate = '{user}', d_update = GETDATE()
    WHERE id_GTIN = '{idGtin}' AND id_size = '{idSize}'
ELSE
    INSERT INTO Pack_PricePerSize (id_price, id_GTIN, id_size, userCreate, d_create)
    VALUES ('{idPrice}', '{idGtin}', '{idSize}', '{user}', GETDATE())
```

Y luego se limpian los registros que no están en la lista:
```sql
UPDATE Pack_PricePerSize 
SET id_price = NULL, userUpdate = '{user}', d_update = GETDATE()
WHERE id_price = '{idPrice}' 
AND CONCAT(id_GTIN, id_size) NOT IN (combinaciones seleccionadas)
```

## Cómo Usar el Sistema

### Alternancia entre GTIN y GTIN+Tamaño
Para cambiar el tipo de precio a manejar:
```csharp
// Para GTIN solamente
cls.CurrentPricingType = PricingType.Gtin;

// Para GTIN + Tamaño
cls.CurrentPricingType = PricingType.GtinAndSize;
```

### Flujo de Usuario

1. **En el Catálogo de Precios**
   - Se muestra el dgvCatalogGtin (precios por GTIN)
   - Se muestra el dgvCatalogSize (precios por GTIN + Tamaño) en el panel inferior
   - Ambos pueden ser filtrados independientemente

2. **En el Formulario de Asignación**
   - El usuario selecciona un precio desde el catálogo
   - Se abre FrmPricesGtinAdd
   - A la izquierda ve todos los GTINs no asignados (o sin el precio seleccionado)
   - A la derecha ve los que ya tienen este precio asignado
   - Puede mover filas de un lado a otro usando los botones Agregar/Quitar
   - Los filtros solo afectan el lado izquierdo
   - Al hacer clic en Aceptar, los cambios se guardan en la base de datos
   - Al hacer clic en Cancelar, se cierra sin guardar

## Notas Técnicas

### Resolución de Conflictos de Nombres
Se utilizó un alias `SizeInfo` para referirse a `ClsObject.Size` para evitar conflictos con `System.Drawing.Size`.

### Escalabilidad
El sistema está diseñado para ser completamente escalable:
- La interfaz del formulario Add funciona para ambos tipos de precios
- Nuevos tipos pueden ser añadidos al enum `PricingType`
- Los métodos de guardado están separados por tipo para facilitar la lógica específica

### Auditoría
Se registran:
- `userCreate` y `d_create` cuando se crea un registro
- `userUpdate` y `d_update` cuando se modifica un registro
- El usuario se obtiene de `Environment.UserName`

## Testing Recomendado

1. Probar la creación de precios por GTIN (funcionalidad existente mejorada)
2. Probar la creación de precios por GTIN + Tamaño (nueva funcionalidad)
3. Probar los filtros en ambos DataGridViews
4. Probar el movimiento de filas entre left y right
5. Probar que los filtros solo afecten el dgvPricesLeft
6. Verificar que los datos se guarden correctamente en la base de datos
7. Probar el soft delete (poner id_price = NULL)
