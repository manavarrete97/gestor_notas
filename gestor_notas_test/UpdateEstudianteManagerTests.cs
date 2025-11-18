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
 public class UpdateEstudianteManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IUpdateEstudianteDAO> _updateEstudianteDAOMock;
 private UpdateEstudianteManager _updateEstudianteManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _updateEstudianteDAOMock = new Mock<IUpdateEstudianteDAO>();
 _updateEstudianteManager = new UpdateEstudianteManager(_postgresConnectionMock.Object, _updateEstudianteDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task UpdateEstudianteAsync_ShouldReturnTrue_WhenSuccessful()
 {
 // Arrange
 var estudianteDTO = new EstudianteDTO { Id =1, Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _updateEstudianteDAOMock.Setup(p => p.UpdateEstudianteAsync(It.IsAny<NpgsqlConnection>(), estudianteDTO)).ReturnsAsync(true);

 // Act
 var result = await _updateEstudianteManager.UpdateEstudianteAsync(estudianteDTO);

 // Assert
 Assert.That(result, Is.True);
 }

 [Test]
 public async Task UpdateEstudianteAsync_ShouldReturnFalse_WhenFails()
 {
 // Arrange
 var estudianteDTO = new EstudianteDTO { Id =1, Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _updateEstudianteDAOMock.Setup(p => p.UpdateEstudianteAsync(It.IsAny<NpgsqlConnection>(), estudianteDTO)).ReturnsAsync(false);

 // Act
 var result = await _updateEstudianteManager.UpdateEstudianteAsync(estudianteDTO);

 // Assert
 Assert.That(result, Is.False);
 }
 }
}