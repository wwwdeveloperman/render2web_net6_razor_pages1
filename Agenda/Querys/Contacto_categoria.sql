select  Contactos.nombre as "Contacto", Categorias.nombre as "Categoria"
from Contactos, Categorias
where Contactos.Id = Categorias.Id;