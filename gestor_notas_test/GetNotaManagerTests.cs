using gestor_notas.DTO;
using gestor_notas.Manager;
using gestor_notas.DAO.Interface;
using gestor_notas.Common.Interface;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas_test
{
 [TestFixture]
 public class GetNotaManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IGetNotaDAO> _getNotaDAOMock;
 private GetNotaManager _getNotaManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _getNotaDAOMock = new Mock<IGetNotaDAO>();
 _getNotaManager = new GetNotaManager(_postgresConnectionMock.Object, _getNotaDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task GetNotaByEstudianteAndMateriaAsync_ShouldReturnNota_WhenExists()
 {
 // Arrange
 var notaDTO = new NotaDTO { Id =1, Nombre = "Nota1", IdMateria =2, IdEstudiante =3, Valor =9.5m };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _getNotaDAOMock.Setup(p => p.GetNotaByEstudianteAndMateriaAsync(It.IsAny<NpgsqlConnection>(),3,2)).ReturnsAsync(notaDTO);

 // Act
 var result = await _getNotaManager.GetNotaByEstudianteAndMateriaAsync(3,2);

 // Assert
 Assert.That(result, Is.Not.Null);
 Assert.That(result.Id, Is.EqualTo(notaDTO.Id));
 Assert.That(result.Nombre, Is.EqualTo(notaDTO.Nombre));
 Assert.That(result.IdMateria, Is.EqualTo(notaDTO.IdMateria));
 Assert.That(result.IdEstudiante, Is.EqualTo(notaDTO.IdEstudiante));
 Assert.That(result.Valor, Is.EqualTo(notaDTO.Valor));
 }

 [Test]
 public async Task GetNotaByEstudianteAndMateriaAsync_ShouldReturnNull_WhenNotExists()
 {
 // Arrange
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _getNotaDAOMock.Setup(p => p.GetNotaByEstudianteAndMateriaAsync(It.IsAny<NpgsqlConnection>(),3,2)).ReturnsAsync((NotaDTO)null);

 // Act
 var result = await _getNotaManager.GetNotaByEstudianteAndMateriaAsync(3,2);

 // Assert
 Assert.That(result, Is.Null);
 }

 [Test]
 public async Task GetNotasByMateriaAsync_ShouldReturnListOfNotas()
 {
 // Arrange
 var notas = new List<NotaDTO>
 {
 new NotaDTO { Id =1, Nombre = "Nota1", IdMateria =2, IdEstudiante =3, Valor =9.5m },
 new NotaDTO { Id =2, Nombre = "Nota2", IdMateria =2, IdEstudiante =4, Valor =8.0m }
 };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _getNotaDAOMock.Setup(p => p.GetNotasByMateriaAsync(It.IsAny<NpgsqlConnection>(),2)).ReturnsAsync(notas);

 // Act
 var result = await _getNotaManager.GetNotasByMateriaAsync(2);

 // Assert
 Assert.That(result, Is.Not.Null);
 Assert.That(result.Count, Is.EqualTo(2));
 }
 }
}