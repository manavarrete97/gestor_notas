using gestor_notas.DTO;
using gestor_notas.Manager;
using gestor_notas.DAO.Interface;
using gestor_notas.Common.Interface;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas_test
{
 [TestFixture]
 public class PostNotaManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IPostNotaDAO> _postNotaDAOMock;
 private PostNotaManager _postNotaManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _postNotaDAOMock = new Mock<IPostNotaDAO>();
 _postNotaManager = new PostNotaManager(_postgresConnectionMock.Object, _postNotaDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task AddNotaAsync_ShouldReturnTrue_WhenSuccessful()
 {
 // Arrange
 var notaDTO = new NotaDTO { Nombre = "Nota1", IdMateria =2, IdEstudiante =3, Valor =9.5m };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _postNotaDAOMock.Setup(p => p.ValidateEstudianteAndMateriaExistAsync(It.IsAny<NpgsqlConnection>(),3,2)).ReturnsAsync(true);
 _postNotaDAOMock.Setup(p => p.AddNotaAsync(It.IsAny<NpgsqlConnection>(), notaDTO)).ReturnsAsync(true);

 // Act
 var result = await _postNotaManager.AddNotaAsync(notaDTO);

 // Assert
 Assert.That(result, Is.True);
 }

 [Test]
 public void AddNotaAsync_ShouldThrowException_WhenEstudianteOrMateriaNotExist()
 {
 // Arrange
 var notaDTO = new NotaDTO { Nombre = "Nota1", IdMateria =2, IdEstudiante =3, Valor =9.5m };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _postNotaDAOMock.Setup(p => p.ValidateEstudianteAndMateriaExistAsync(It.IsAny<NpgsqlConnection>(),3,2)).ReturnsAsync(false);

 // Act & Assert
 Assert.ThrowsAsync<Exception>(async () => await _postNotaManager.AddNotaAsync(notaDTO), "El estudiante o la materia no existen.");
 }
 }
}