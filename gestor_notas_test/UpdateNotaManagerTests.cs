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
 public class UpdateNotaManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IUpdateNotaDAO> _updateNotaDAOMock;
 private UpdateNotaManager _updateNotaManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _updateNotaDAOMock = new Mock<IUpdateNotaDAO>();
 _updateNotaManager = new UpdateNotaManager(_postgresConnectionMock.Object, _updateNotaDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task UpdateNotaAsync_ShouldReturnTrue_WhenSuccessful()
 {
 // Arrange
 var idNota =1;
 var valor =9.5m;
 var idProfesor =2;
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _updateNotaDAOMock.Setup(p => p.ValidateProfesorForMateriaAsync(It.IsAny<NpgsqlConnection>(), idProfesor, idNota)).ReturnsAsync(true);
 _updateNotaDAOMock.Setup(p => p.UpdateNotaAsync(It.IsAny<NpgsqlConnection>(), idNota, valor, idProfesor)).ReturnsAsync(true);

 // Act
 var result = await _updateNotaManager.UpdateNotaAsync(idNota, valor, idProfesor);

 // Assert
 Assert.That(result, Is.True);
 }

 [Test]
 public void UpdateNotaAsync_ShouldThrowException_WhenProfesorNotAuthorized()
 {
 // Arrange
 var idNota =1;
 var valor =9.5m;
 var idProfesor =2;
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _updateNotaDAOMock.Setup(p => p.ValidateProfesorForMateriaAsync(It.IsAny<NpgsqlConnection>(), idProfesor, idNota)).ReturnsAsync(false);

 // Act & Assert
 Assert.ThrowsAsync<Exception>(async () => await _updateNotaManager.UpdateNotaAsync(idNota, valor, idProfesor), "El profesor no está autorizado para esta materia.");
 }
 }
}